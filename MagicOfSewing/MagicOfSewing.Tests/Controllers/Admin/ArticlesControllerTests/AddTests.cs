namespace MagicOfSewing.Tests.Controllers.Admin.ArticlesControllerTests
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
        public void Add_WithValidArticle_ShouldCallService()
        {
            // Arrange
            var model = new ArticleCreationBindingModel();
            bool serviceCalled = false;
            var mockRepository = new Mock<IAdminArticlesService>();
            mockRepository.Setup(repo => repo.AddArticleAsync(model))
                .Callback(() => serviceCalled = true);

            var userRepository = new Mock<IAdminUsersService>();
            userRepository.Setup(repo => repo.GetAuthorsAsync())
                .Callback(() => serviceCalled = true);

            var controller = new ArticlesController(userRepository.Object, mockRepository.Object);

            // Act
            var result = controller.Add(model);

            // Assert
            Assert.IsTrue(serviceCalled);
        }
    }
}
