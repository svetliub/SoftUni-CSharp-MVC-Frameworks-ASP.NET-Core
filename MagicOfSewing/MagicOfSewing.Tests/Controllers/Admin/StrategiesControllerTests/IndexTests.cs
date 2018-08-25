namespace MagicOfSewing.Tests.Controllers.Admin.StrategiesControllerTests
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
        public async Task Index_ReturnsAllStrategies()
        {
            // Arrange
            var strategyModel = new StrategyConciseViewModel() { Id = 1, Title = "First" };
            bool methodCalled = false;

            var mockRepository = new Mock<IAdminStrategiesService>();
            mockRepository.Setup(s => s.GetAllStrategiesAsync())
                .ReturnsAsync(new[] { strategyModel })
                .Callback(() => methodCalled = true);

            var controller = new StrategiesController(mockRepository.Object);

            // Act
            var result = await controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var resultView = result as ViewResult;
            Assert.IsNotNull(resultView.Model);
            Assert.IsInstanceOfType(resultView.Model, typeof(IEnumerable<StrategyConciseViewModel>));
            Assert.IsTrue(methodCalled);
        }
    }
}
