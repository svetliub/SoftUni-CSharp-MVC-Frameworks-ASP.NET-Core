namespace MagicOfSewing.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using MagicOfSewing.Web.Models;
    using System.Threading.Tasks;
    using MagicOfSewing.Services.Users.Interfaces;
    using System;
    using System.Linq;
    using static MagicOfSewing.Common.Constants.WebConstants;
    using MagicOfSewing.Web.Common;
    using MagicOfSewing.Common.Admin.ViewModels;

    public class HomeController : Controller
    {
        private readonly IArticlesService articlesService;
        private readonly IVideosService videosService;
        private readonly IUsersService usersService;

        public HomeController(IArticlesService articlesService, IUsersService usersService, IVideosService videosService)
        {
            this.articlesService = articlesService;
            this.videosService = videosService;
            this.usersService = usersService;
        }

        public IActionResult Index()
        {
            if (this.User.IsInRole("Administrator"))
            {
                return RedirectToAction("index", "home", new { area = "admin" });
            }

            return View();
        }

        public async Task<IActionResult> About()
        {
            var authors = await this.usersService.GetAuthorsAsync();

            return View(authors);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> ArticlesBy(string id, int pageIndex = 1)
        {
            pageIndex = Math.Max(1, pageIndex);

            var articles = await this.articlesService.GetArticlesByAsync(id);

            var totalPages = Math.Max(1, (int)Math.Ceiling(articles.Count() / (double)UsersArticlesCountOnPage));
            pageIndex = Math.Min(pageIndex, totalPages);

            var articlesToShow = articles
                .Skip((pageIndex - 1) * UsersArticlesCountOnPage)
                .Take(UsersArticlesCountOnPage)
                .ToList();

            var model = new PaginatedList<ArticleConciseViewModel>(articlesToShow, pageIndex, totalPages);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> VideosBy(string id, int pageIndex = 1)
        {
            pageIndex = Math.Max(1, pageIndex);

            var videos = await this.videosService.GetVideosByAsync(id);

            var totalPages = Math.Max(1, (int)Math.Ceiling(videos.Count() / (double)UsersVideosCountOnPage));
            pageIndex = Math.Min(pageIndex, totalPages);

            var videosToShow = videos
                .Skip((pageIndex - 1) * UsersVideosCountOnPage)
                .Take(UsersVideosCountOnPage)
                .ToList();

            var model = new PaginatedList<VideoConciseViewModel>(videosToShow, pageIndex, totalPages);

            return View(model);
        }
    }
}
