using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatesInfoProviderApp.Entity;
using StatesInfoProviderApp.DomainServices.Contracts;

namespace StatesInfoProviderApp
{
	public class StateInfoProvider : IStateInfoProvider
	{
		public IStateInfoService _stateInfoService;

		public StateInfoProvider(IStateInfoService stateInfoService)
		{
			_stateInfoService = stateInfoService;
		}

		/// <summary>
		/// Retrieves State info based on user input
		/// </summary>
		/// <param name="name">Name/Abbreviation of the state</param>
		/// <returns></returns>
		public StateInfo GetStateInfo(string name)
		{
			return _stateInfoService.GetStateInfo(name);
		}
	}
}
