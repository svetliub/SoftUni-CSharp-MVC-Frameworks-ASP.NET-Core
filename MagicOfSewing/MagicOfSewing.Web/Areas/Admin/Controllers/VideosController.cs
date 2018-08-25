namespace MagicOfSewing.Web.Areas.Admin.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using MagicOfSewing.Common.Admin.BindingModels;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Services.Admin.Interfaces;
    using MagicOfSewing.Web.Common;
    using MagicOfSewing.Web.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static MagicOfSewing.Common.Constants.WebConstants;

    public class VideosController : AdminController
    {
        private const string Video = "video";

        private readonly IAdminUsersService usersService;
        private readonly IAdminVideosService videosService;

        public VideosController(IAdminUsersService usersService, IAdminVideosService videosService)
        {
            this.usersService = usersService;
            this.videosService = videosService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageIndex = 1)
        {
            pageIndex = Math.Max(1, pageIndex);

            var videos = await this.videosService.GetAllVideosAsync();

            var totalPages = Math.Max(1, (int)Math.Ceiling(videos.Count() / (double)VideosCountOnPage));
            pageIndex = Math.Min(pageIndex, totalPages);

            var videosToShow = videos
                .Skip((pageIndex - 1) * VideosCountOnPage)
                .Take(VideosCountOnPage)
                .ToList();

            var model = new PaginatedList<VideoConciseViewModel>(videosToShow, pageIndex, totalPages);

            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var authors = await this.usersService.GetAuthorsAsync();
            this.ViewData["Authors"] = authors;

            return View();
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Add(VideoCreationBindingModel model)
        {
            var video = await this.videosService.AddVideoAsync(model);

            SetSuccesfullMessage(AddedSuccessfully, Video);

            return this.RedirectToAction("Details", new { id = video.Id, slug = video.Slug });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, string slug)
        {
            var model = await this.videosService.GetVideoDetailsAsync(id, slug);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, string slug)
        {
            var authors = await this.usersService.GetAuthorsAsync();
            this.ViewData["Authors"] = authors;

            var video = await this.videosService.GetVideoEditAsync(id, slug);

            return View(video);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VideoEditBindingModel model)
        {
            var video = await this.videosService.EditVideoAsync(model);

            SetSuccesfullMessage(EditedSuccessfully, Video);

            return this.RedirectToAction("Details", new { id = video.Id, slug = video.Slug });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, string slug)
        {
            await this.videosService.DeleteVideo(id, slug);

            SetSuccesfullMessage(DeletedSuccessfully, Video);

            return this.RedirectToAction("Index");
        }
    }
}