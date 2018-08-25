namespace MagicOfSewing.Tests.Controllers.Admin.UsersControllerTests
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MagicOfSewing.Common.Constants;
    using MagicOfSewing.Web.Areas.Admin.Controllers;
    using System.Security.Claims;

    [TestClass]
    public class IndexTests
    {
        [TestMethod]
        public void Index_ShouldBeAccessibleByAdmin()
        {
            // Arrange
            var controller = new UsersController(null);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Role, WebConstants.AdminRole)
                    }))
                }
            };

            Assert.IsTrue(controller.User.IsInRole(WebConstants.AdminRole));
        }
    }
}
