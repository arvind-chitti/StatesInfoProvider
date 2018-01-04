using StatesInfoProviderApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesInfoProviderApp.DomainServices.Contracts
{
	public interface IStateInfoService
	{
		StateInfo GetStateInfo(string name);
	}
}
