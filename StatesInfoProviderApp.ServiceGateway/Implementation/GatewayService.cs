using StatesInfoProviderApp.ServiceGateway.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using StatesInfoProviderApp.Entity;
using StatesInfoProviderApp.Common.Resources;
using StatesInfoProviderApp.Common.Exceptions;

namespace StatesInfoProviderApp.ServiceGateway.Implementation
{
	public class GatewayService : IGatewayService
	{
		public ResponseObj GetStatesInfo()
		{
			try
			{
				var restResponse = new ResponseObj();
				// TODO: Get the URL from Config.
				var restRequest = WebRequest.Create("http://services.groupkt.com/state/get/USA/all") as HttpWebRequest;

				if (restRequest != null)
				{
					restRequest.Method = "GET";
					restRequest.ContentType = "application/json";

					var httpResponse = restRequest.GetResponse() as HttpWebResponse;

					if (httpResponse != null)
					{
						restResponse.StatusCode = httpResponse.StatusCode.ToString();
						restResponse.ResponseStream = httpResponse.GetResponseStream();
					}
				}
				else
				{
					var ex = new Exception(Constants.Logging.Message.RESTFulRequestError);
					throw new GatewayServiceException(ex, Constants.Logging.Message.RESTFulRequestError);
				}

				return restResponse;
			}
			catch (WebException webEx)
			{
				throw webEx;
			}
			catch (Exception ex)
			{
				throw new GatewayServiceException(ex, Constants.Logging.Message.GatewayServiceError);
			}
		}
	}
}
