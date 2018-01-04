using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesInfoProviderApp.Entity
{
	public class RestResponse
	{
		public string[] messages { get; set; }
		public StateInfo[] result;
	}

	public class RootObject
	{
		public RestResponse RestResponse { get; set; }
	}
}
