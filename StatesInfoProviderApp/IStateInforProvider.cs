using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatesInfoProviderApp.Entity;

namespace StatesInfoProviderApp
{
	public interface IStateInfoProvider
	{
		StateInfo GetStateInfo(string name);
	}
}
