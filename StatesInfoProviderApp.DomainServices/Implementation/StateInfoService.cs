using StatesInfoProviderApp.DomainServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatesInfoProviderApp.Entity;
using StatesInfoProviderApp.ServiceGateway.Contracts;
using System.IO;
using StatesInfoProviderApp.Common.Exceptions;
using StatesInfoProviderApp.Common.Resources;
using System.Net;

namespace StatesInfoProviderApp.DomainServices.Implementation
{
	public class StateInfoService : ServiceBase, IStateInfoService
	{
		private readonly IGatewayService _gatewayService;
		public StateInfoService(IGatewayService gatewayService)
		{
			_gatewayService = gatewayService;
		}

		/// <summary>
		/// Domain service method to return state info based on input
		/// </summary>
		/// <param name="name">State name or abbreviation</param>
		/// <returns>StateInfo object with state info</returns>
		public StateInfo GetStateInfo(string name)
		{
			// Valid input check
			if (string.IsNullOrEmpty(name))
			{				
				throw new DomainServiceException(Constants.Logging.Message.EmptyInputWarning);
			}

			try
			{
				var stateInfo = new StateInfo();

				// External service call.
				var restResponse = _gatewayService.GetStatesInfo();

				using (Stream responseStream = restResponse.ResponseStream)
				{
					StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
					var jsonstring = reader.ReadToEnd();
					var rootObject = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(jsonstring);

					var states = rootObject.RestResponse.result;
					stateInfo = states?.FirstOrDefault(x => x.name.ToUpper() == name.ToUpper() || x.abbr.ToUpper() == name.ToUpper());
				}

				return stateInfo;
			}
			catch (WebException webEx)
			{
				LoggingService.Log(webEx.Message);
				throw new DomainServiceException(webEx, Constants.Logging.Message.IssueWithRESTFulService);
			}
			catch (GatewayServiceException gsEx)
			{
				LoggingService.Log(gsEx.Message);
				throw new DomainServiceException(gsEx, Constants.Logging.Message.GatewayServiceError);
			}
			catch (Exception ex)
			{
				LoggingService.Log(ex.Message);
				throw new DomainServiceException(ex, Constants.Logging.Message.StatesInfoNotRetrieved);
			}
		}
	}

	
}
