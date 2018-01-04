using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesInfoProviderApp.Common.Resources
{
	public static class Constants
	{
		public static class Logging
		{
			public static class Message
			{
				public const string StatesInfoNotRetrieved = "Error occured retrieving the states information";
				public const string IssueWithRESTFulService = "Error occured in RESTFul service";
				public const string GatewayServiceError = "Error occured in gateway service";
				public const string RESTFulRequestError = "Issue with RESTFul request";
				public const string EmptyInputWarning = "Please enter a valid input";
			}
		}
	}
}
