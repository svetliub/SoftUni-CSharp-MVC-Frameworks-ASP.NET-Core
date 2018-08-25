namespace MagicOfSewing.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Services.Admin.Interfaces;
    using MagicOfSewing.Web.Common;
    using Microsoft.AspNetCore.Mvc;
    using static MagicOfSewing.Common.Constants.WebConstants;

    public class UsersController : AdminController
    {
        private readonly IAdminUsersService usersService;

        public UsersController(IAdminUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageIndex = 1)
        {
            pageIndex = Math.Max(1, pageIndex);

            var users = await this.usersService.GetAllUsersAsync();

            var totalPages = Math.Max(1, (int)Math.Ceiling(users.Count() / (double)UsersCountOnPage));
            pageIndex = Math.Min(pageIndex, totalPages);

            var videosToShow = users
                .Skip((pageIndex - 1) * UsersCountOnPage)
                .Take(UsersCountOnPage)
                .ToList();

            var model = new PaginatedList<UserConciseViewModel>(videosToShow, pageIndex, totalPages);

            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var model = await this.usersService.GetUserDetailsAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await this.usersService.DeleteUser(id);

            SetSuccesfullMessage(DeletedSuccessfully, "user");

            return this.RedirectToAction("Index");
        }
    }
}