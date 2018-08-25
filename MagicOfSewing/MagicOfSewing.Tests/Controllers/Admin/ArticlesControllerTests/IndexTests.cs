namespace MagicOfSewing.Tests.Controllers.Admin.ArticlesControllerTests
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
        public async Task Index_ReturnsAllArticles()
        {
            // Arrange
            var articleModel = new ArticleConciseViewModel() { Id = 1, Title = "First" };
            bool methodCalled = false;

            var mockRepository = new Mock<IAdminArticlesService>();
            mockRepository.Setup(s => s.GetAllArticlesAsync())
                .ReturnsAsync(new[] { articleModel })
                .Callback(() => methodCalled = true);

            var userRepository = new Mock<IAdminUsersService>();
            userRepository.Setup(repo => repo.GetAuthorsAsync())
                .Callback(() => methodCalled = true);

            var controller = new ArticlesController(userRepository.Object, mockRepository.Object);

            // Act
            var result = await controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var resultView = result as ViewResult;
            Assert.IsNotNull(resultView.Model);
            Assert.IsInstanceOfType(resultView.Model, typeof(IEnumerable<ArticleConciseViewModel>));
            Assert.IsTrue(methodCalled);
        }
    }
}
