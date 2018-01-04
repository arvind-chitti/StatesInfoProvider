using StatesInfoProviderApp.Common;
using StatesInfoProviderApp.Common.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesInfoProviderApp.DomainServices
{
	public class ServiceBase : IDisposable
	{
		public ILoggingService LoggingService { get; set; }

		public ServiceBase()
		{
			LoggingService = new LoggingService();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool isDisposing)
		{
			// Dispose of any objects here. (Eg: UnitOfWork, etc)
		}
	}
}
