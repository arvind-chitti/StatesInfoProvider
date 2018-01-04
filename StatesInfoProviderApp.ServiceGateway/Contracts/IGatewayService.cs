using StatesInfoProviderApp.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesInfoProviderApp.ServiceGateway.Contracts
{
	public interface IGatewayService
	{
		ResponseObj GetStatesInfo();
	}
}
