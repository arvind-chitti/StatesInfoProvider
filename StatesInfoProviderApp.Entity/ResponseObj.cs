using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesInfoProviderApp.Entity
{
	public class ResponseObj
	{
		public string StatusCode { get; set; }
		public Stream ResponseStream { get; set; }
	}
}
