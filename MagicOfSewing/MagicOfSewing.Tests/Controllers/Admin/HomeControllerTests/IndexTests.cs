namespace MagicOfSewing.Tests.Controllers.Admin.HomeControllerTests
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MagicOfSewing.Web.Areas.Admin.Controllers;

    [TestClass]
    public class IndexTests
    {
        [TestMethod]
        public void Index_ReturnsTheProperView()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
