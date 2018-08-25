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

    public class PostsController : AdminController
    {
        private readonly IAdminPostsService postsService;

        public PostsController(IAdminPostsService postsService)
        {
            this.postsService = postsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageIndex = 1)
        {
            pageIndex = Math.Max(1, pageIndex);

            var posts = await this.postsService.GetAllPostsAsync();

            var totalPages = Math.Max(1, (int)Math.Ceiling(posts.Count() / (double)PostsCountOnPage));
            pageIndex = Math.Min(pageIndex, totalPages);

            var postsToShow = posts
                .Skip((pageIndex - 1) * PostsCountOnPage)
                .Take(PostsCountOnPage)
                .ToList();

            var model = new PaginatedList<PostConciseViewModel>(postsToShow, pageIndex, totalPages);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {
            await this.postsService.ApprovePost(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UnApprove(int id)
        {
            await this.postsService.UnApprovePost(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.postsService.DeletePost(id);

            SetSuccesfullMessage(DeletedSuccessfully, "post");

            return RedirectToAction("Index");
        }
    }
}