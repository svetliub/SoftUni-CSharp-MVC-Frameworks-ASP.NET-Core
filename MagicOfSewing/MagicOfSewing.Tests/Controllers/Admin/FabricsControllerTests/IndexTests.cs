namespace MagicOfSewing.Tests.Controllers.Admin.FabricsControllerTests
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Services.Admin.Interfaces;
    using MagicOfSewing.Web.Areas.Admin.Controllers;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [TestClass]
    public class IndexTests
    {
        [TestMethod]
        public async Task Index_ReturnsAllFabrics()
        {
            // Arrange
            var fabricModel = new FabricConciseViewModel() { Id = 1, Name = "First" };
            bool methodCalled = false;

            var mockRepository = new Mock<IAdminFabricsService>();
            mockRepository.Setup(s => s.GetAllFabricsAsync())
                .ReturnsAsync(new[] { fabricModel })
                .Callback(() => methodCalled = true);

            var controller = new FabricsController(mockRepository.Object);

            // Act
            var result = await controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var resultView = result as ViewResult;
            Assert.IsNotNull(resultView.Model);
            Assert.IsInstanceOfType(resultView.Model, typeof(IEnumerable<FabricConciseViewModel>));
            Assert.IsTrue(methodCalled);
        }
    }
}
