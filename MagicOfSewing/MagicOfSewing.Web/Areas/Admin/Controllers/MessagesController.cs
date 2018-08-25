namespace MagicOfSewing.Web.Areas.Admin.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Services.Admin.Interfaces;
    using MagicOfSewing.Web.Common;
    using Microsoft.AspNetCore.Mvc;
    using static MagicOfSewing.Common.Constants.WebConstants;

    public class MessagesController : AdminController
    {
        private readonly IAdminMessagesServices messagesServices;

        public MessagesController(IAdminMessagesServices messagesServices)
        {
            this.messagesServices = messagesServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageIndex = 1)
        {
            pageIndex = Math.Max(1, pageIndex);

            var messages = await this.messagesServices.GetAllMessagesAsync();

            var totalPages = Math.Max(1, (int)Math.Ceiling(messages.Count() / (double)MessagesCountOnPage));
            pageIndex = Math.Min(pageIndex, totalPages);

            var videosToShow = messages
                .Skip((pageIndex - 1) * MessagesCountOnPage)
                .Take(MessagesCountOnPage)
                .ToList();

            var model = new PaginatedList<MessageConciseViewModel>(videosToShow, pageIndex, totalPages);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var message = await this.messagesServices.GetMessageDetailsAsync(id);

            if(message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        [HttpPost]
        public async Task<IActionResult> Answer(int id)
        {
            await this.messagesServices.AnswerMessage(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.messagesServices.DeleteMessage(id);

            SetSuccesfullMessage(DeletedSuccessfully, "message");

            return RedirectToAction("Index");
        }
    }
}