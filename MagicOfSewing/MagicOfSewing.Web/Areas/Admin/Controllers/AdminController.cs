namespace MagicOfSewing.Web.Areas.Admin.Controllers
{
    using MagicOfSewing.Common.Constants;
    using MagicOfSewing.Web.Common;
    using MagicOfSewing.Web.Helpers.Messages;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdminRole)]
    public abstract class AdminController : Controller
    {
        protected void SetSuccesfullMessage(string message, string parameter)
        {
            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = string.Format(message, parameter)
            });
        }
    }
}