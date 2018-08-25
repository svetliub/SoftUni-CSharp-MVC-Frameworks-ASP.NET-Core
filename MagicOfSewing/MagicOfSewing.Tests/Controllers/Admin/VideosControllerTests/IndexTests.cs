namespace MagicOfSewing.Tests.Controllers.Admin.VideosControllerTests
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
        public async Task Index_ReturnsAllVideos()
        {
            // Arrange
            var videoModel = new VideoConciseViewModel() { Id = 1, Title = "First" };
            bool methodCalled = false;

            var mockRepository = new Mock<IAdminVideosService>();
            mockRepository.Setup(s => s.GetAllVideosAsync())
                .ReturnsAsync(new[] { videoModel })
                .Callback(() => methodCalled = true);

            var userRepository = new Mock<IAdminUsersService>();
            userRepository.Setup(repo => repo.GetAuthorsAsync())
                .Callback(() => methodCalled = true);

            var controller = new VideosController(userRepository.Object, mockRepository.Object);

            // Act
            var result = await controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var resultView = result as ViewResult;
            Assert.IsNotNull(resultView.Model);
            Assert.IsInstanceOfType(resultView.Model, typeof(IEnumerable<VideoConciseViewModel>));
            Assert.IsTrue(methodCalled);
        }
    }
}
