using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesInfoProviderApp.Common.Exceptions
{
	public class DomainServiceException : BaseException
	{
		public readonly Exception _exception;
		public string MessageToDisplay { get; set; }

		public DomainServiceException(string messageToDisplay)
		{			
			MessageToDisplay = messageToDisplay;
		}

		public DomainServiceException(Exception exception, string messageToDisplay)
		{
			_exception = exception;
			MessageToDisplay = messageToDisplay;
		}
	}
}
