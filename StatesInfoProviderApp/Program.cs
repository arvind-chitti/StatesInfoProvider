using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Unity;
using StatesInfoProviderApp.DomainServices.Contracts;
using StatesInfoProviderApp.DomainServices.Implementation;
using StatesInfoProviderApp.ServiceGateway.Contracts;
using StatesInfoProviderApp.ServiceGateway.Implementation;
using StatesInfoProviderApp.Common;
using StatesInfoProviderApp.Common.Implementation;
using static System.FormattableString;
using StatesInfoProviderApp.Common.Exceptions;

namespace StatesInfoProviderApp
{
	class Program
	{
		private static IUnityContainer Container { get; set; }
		static void Main(string[] args)
		{
			// We can also set up container using configuration set up.
			SetUpContainer();

			while (true)
			{
				Console.WriteLine();
				Console.WriteLine("Please enter the name of the state or the abbreviation to search for or type in EXIT to exit");
				var input = Console.ReadLine();

				if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
				{
					break;
				}
				try
				{
					var stateInfoProvider = Container.Resolve<IStateInfoProvider>();
					var stateInfo = stateInfoProvider.GetStateInfo(input);

					if (stateInfo != null)
					{
						Console.WriteLine($"Largest City: {stateInfo.largest_city}, Capital City: {stateInfo.capital}");
					}
					else
					{
						Console.WriteLine("No state found");
					}
				}
				catch (DomainServiceException dEx)
				{
					Console.WriteLine(dEx.MessageToDisplay);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}

		public static void SetUpContainer()
		{
			Container = new UnityContainer();
			Container.RegisterType<IStateInfoProvider, StateInfoProvider>();
			Container.RegisterType<IStateInfoService, StateInfoService>();
			Container.RegisterType<IGatewayService, GatewayService>();
			Container.RegisterInstance(typeof(ILoggingService), "LoggingService", new LoggingService());
		}
	}
}
