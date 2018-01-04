using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using StatesInfoProviderApp.ServiceGateway.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using static System.FormattableString;
using StatesInfoProviderApp.Entity;
using StatesInfoProviderApp.Common;

namespace StateInfoProviderApp.DomainServices.Tests
{
	public class BaseDomainServiceTests
	{
		protected Mock<IGatewayService> MockGatewayService;
		protected Mock<ILoggingService> MockLoggingService;

		[TestInitialize()]
		[DeploymentItem(@"TestData\AllStates.txt")]
		public void Initialize()
		{
			MockGatewayService = new Mock<IGatewayService>();
			MockLoggingService = new Mock<ILoggingService>();

			var fileStream = File.OpenRead(Invariant($"{AppDomain.CurrentDomain.BaseDirectory}\\TestData\\AllStates.txt"));
			var gatewayServiceResponseObj = new ResponseObj();
			gatewayServiceResponseObj.ResponseStream = fileStream;

			MockGatewayService.Setup(x => x.GetStatesInfo()).Returns(gatewayServiceResponseObj);
			MockLoggingService.Setup(x => x.Log(It.IsAny<string>())).Verifiable();
		}
	}
}
