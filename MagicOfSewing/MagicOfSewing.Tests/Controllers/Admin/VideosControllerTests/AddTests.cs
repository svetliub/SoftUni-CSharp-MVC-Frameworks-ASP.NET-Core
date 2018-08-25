namespace MagicOfSewing.Tests.Controllers.Admin.VideosControllerTests
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
        public void Add_WithValidVideo_ShouldCallService()
        {
            // Arrange
            var model = new VideoCreationBindingModel();
            bool serviceCalled = false;
            var mockRepository = new Mock<IAdminVideosService>();
            mockRepository.Setup(repo => repo.AddVideoAsync(model))
                .Callback(() => serviceCalled = true);

            var userRepository = new Mock<IAdminUsersService>();
            userRepository.Setup(repo => repo.GetAuthorsAsync())
                .Callback(() => serviceCalled = true);

            var controller = new VideosController(userRepository.Object, mockRepository.Object);

            // Act
            var result = controller.Add(model);

            // Assert
            Assert.IsTrue(serviceCalled);
        }
    }
}
