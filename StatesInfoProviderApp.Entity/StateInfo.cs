using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesInfoProviderApp.Entity
{
    public class StateInfo
    {
		public int id { get; set; }
		public string country { get; set; }
		public string name { get; set; }
		public string abbr { get; set; }
		public string area { get; set; }
		public string largest_city { get; set; }
		public string capital { get; set; }
	}
}
