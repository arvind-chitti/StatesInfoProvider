using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesInfoProviderApp.Common
{
	public interface ILoggingService
	{
		void Log(string errorMessage);
	}
}
