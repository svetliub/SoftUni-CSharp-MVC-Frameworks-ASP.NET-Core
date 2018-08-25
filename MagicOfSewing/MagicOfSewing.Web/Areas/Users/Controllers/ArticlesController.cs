namespace MagicOfSewing.Web.Areas.Users.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Services.Users.Interfaces;
    using MagicOfSewing.Web.Common;
    using Microsoft.AspNetCore.Mvc;
    using static MagicOfSewing.Common.Constants.WebConstants;

    public class ArticlesController : Controller
    {
        private readonly IArticlesService articlesService;

        public ArticlesController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexHowTo(int pageIndex = 1)
        {
            pageIndex = Math.Max(1, pageIndex);

            var articles = await this.articlesService.GetAllHowToArticlesAsync();

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
        public async Task<IActionResult> IndexFashionAndStyle(int pageIndex = 1)
        {
            pageIndex = Math.Max(1, pageIndex);

            var articles = await this.articlesService.GetAllModaAndStyleArticlesAsync();

            var totalPages = Math.Max(1, (int)Math.Ceiling(articles.Count() / (double)UsersArticlesCountOnPage));
            pageIndex = Math.Min(pageIndex, totalPages);

            var articlesToShow = articles
                .Skip((pageIndex - 1) * UsersArticlesCountOnPage)
                .Take(UsersArticlesCountOnPage)
                .ToList();

            var model = new PaginatedList<ArticleConciseViewModel>(articlesToShow, pageIndex, totalPages);

            return View(model);
        }

        //private PaginatedList<ArticleConciseViewModel> Pagination(IEnumerable<ArticleConciseViewModel> articles, int pageIndex = 1)
        //{
        //    pageIndex = Math.Max(1, pageIndex);

        //    var totalPages = Math.Max(1, (int)Math.Ceiling(articles.Count() / (double)UsersArticlesCountOnPage));
        //    pageIndex = Math.Min(pageIndex, totalPages);

        //    var articlesToShow = articles
        //        .Skip((pageIndex - 1) * UsersArticlesCountOnPage)
        //        .Take(UsersArticlesCountOnPage)
        //        .ToList();

        //    var model = new PaginatedList<ArticleConciseViewModel>(articlesToShow, pageIndex, totalPages);

        //    return model;
        //}
    }
}