using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesInfoProviderApp.Common.Exceptions
{
	public class GatewayServiceException : BaseException
	{
		public readonly Exception _exception;

		public GatewayServiceException(Exception exception, string errorMessage)
		{
			_exception = exception;
		}
	}
}
