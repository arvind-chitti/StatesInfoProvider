using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatesInfoProviderApp.DomainServices.Implementation;
using StatesInfoProviderApp.Common.Exceptions;
using StatesInfoProviderApp.Common.Resources;
using Moq;

namespace StateInfoProviderApp.DomainServices.Tests
{
	[TestClass]
	public class StateInfoServiceTests : BaseDomainServiceTests
	{
		[TestMethod]
		//[DeploymentItem(@"TestData\AllStates.txt", "DataFolder")]
		public void GetStateInfo_HappyPath_ShouldReturnStateInfo()
		{
			// ARRANGE
			var input = "AL";
			var stateInfoService = new StateInfoService(MockGatewayService.Object);
			stateInfoService.LoggingService = MockLoggingService.Object;

			// ACT
			var result = stateInfoService.GetStateInfo(input)?.name;

			// ASSERT
			Assert.AreEqual("Alabama", result);
		}

		[TestMethod]
		//[DeploymentItem(@"TestData\AllStates.txt", "DataFolder")]
		public void GetStateInfo_NoMatch_ShouldReturnNull()
		{
			// ARRANGE
			var input = "Not existing state";
			var stateInfoService = new StateInfoService(MockGatewayService.Object);
			stateInfoService.LoggingService = MockLoggingService.Object;

			// ACT
			var result = stateInfoService.GetStateInfo(input)?.name;

			// ASSERT
			Assert.AreEqual(null, result);
		}

		[TestMethod]
		public void GetStateInfo_InputIsCaseInsensitive_ShouldReturnStateInfo()
		{
			// ARRANGE
			var input = "gUaM";
			var stateInfoService = new StateInfoService(MockGatewayService.Object);
			stateInfoService.LoggingService = MockLoggingService.Object;

			// ACT
			var result = stateInfoService.GetStateInfo(input)?.name;

			// ASSERT
			Assert.AreEqual("Guam", result);
		}

		[TestMethod]
		[ExpectedException(typeof(DomainServiceException), Constants.Logging.Message.EmptyInputWarning)]
		public void GetStateInfo_InputIsNull_ShouldThrowDomainServiceException()
		{
			// ARRANGE
			var stateInfoService = new StateInfoService(MockGatewayService.Object);
			stateInfoService.LoggingService = MockLoggingService.Object;

			// ACT
			var result = stateInfoService.GetStateInfo(null)?.name;

			// ASSERT
			Assert.AreEqual("Guam", result);
		}
	}
}
