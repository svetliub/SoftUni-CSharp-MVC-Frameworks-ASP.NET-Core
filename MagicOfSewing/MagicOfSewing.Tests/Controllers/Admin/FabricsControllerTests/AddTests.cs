namespace MagicOfSewing.Tests.Controllers.Admin.FabricsControllerTests
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
        public void Add_WithValidFabric_ShouldCallService()
        {
            // Arrange
            var model = new FabricCreationBindingModel();
            bool serviceCalled = false;
            var mockRepository = new Mock<IAdminFabricsService>();
            mockRepository.Setup(repo => repo.AddFabricAsync(model))
                .Callback(() => serviceCalled = true);

            var controller = new FabricsController(mockRepository.Object);

            // Act
            var result = controller.Add(model);

            // Assert
            Assert.IsTrue(serviceCalled);
        }
    }
}
