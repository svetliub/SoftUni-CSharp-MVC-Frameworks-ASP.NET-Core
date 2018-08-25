namespace MagicOfSewing.Tests.Controllers.Admin.StrategiesControllerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using MagicOfSewing.Common.Admin.BindingModels;
    using MagicOfSewing.Services.Admin.Interfaces;
    using MagicOfSewing.Web.Areas.Admin.Controllers;

    [TestClass]
    public class AddTests
    {
        [TestMethod]
        public void Add_WithValidStrategy_ShouldCallService()
        {
            // Arrange
            var model = new StrategyCreationBindingModel();
            bool serviceCalled = false;
            var mockRepository = new Mock<IAdminStrategiesService>();
            mockRepository.Setup(repo => repo.AddStrategyAsync(model))
                .Callback(() => serviceCalled = true);

            var controller = new StrategiesController(mockRepository.Object);

            // Act
            var result = controller.Add(model);

            // Assert
            Assert.IsTrue(serviceCalled);
        }
    }
}
