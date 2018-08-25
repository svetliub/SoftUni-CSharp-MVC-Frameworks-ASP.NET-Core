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

    public class ArticlesController : AdminController
    {
        private const string ArticleConst = "article";

        private readonly IAdminUsersService usersService;
        private readonly IAdminArticlesService articlesService;

        public ArticlesController(IAdminUsersService usersService, IAdminArticlesService articlesService)
        {
            this.usersService = usersService;
            this.articlesService = articlesService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageIndex = 1)
        {
            pageIndex = Math.Max(1, pageIndex);

            var articles = await this.articlesService.GetAllArticlesAsync();

            var totalPages = Math.Max(1, (int)Math.Ceiling(articles.Count() / (double)ArticlesCountOnPage));
            pageIndex = Math.Min(pageIndex, totalPages);

            var articlesToShow = articles
                .Skip((pageIndex - 1) * ArticlesCountOnPage)
                .Take(ArticlesCountOnPage)
                .ToList();

            var model = new PaginatedList<ArticleConciseViewModel>(articlesToShow, pageIndex, totalPages);

            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var authors = await this.usersService.GetAuthorsAsync();
            var categories = await this.articlesService.GetArticleCategoriesAsync();
            this.ViewData["Authors"] = authors;
            this.ViewData["Categories"] = categories;

            return View();
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Add(ArticleCreationBindingModel model)
        {
            var article = await this.articlesService.AddArticleAsync(model);

            SetSuccesfullMessage(AddedSuccessfully, ArticleConst);

            return this.RedirectToAction("Details", new { id = article.Id, slug = article.Slug });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, string slug)
        {
            var model = await this.articlesService.GetArticleDetailsAsync(id, slug);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, string slug)
        {
            var authors = await this.usersService.GetAuthorsAsync();
            var categories = await this.articlesService.GetArticleCategoriesAsync();
            this.ViewData["Authors"] = authors;
            this.ViewData["Categories"] = categories;

            var article = await this.articlesService.GetArticleEditAsync(id, slug);

            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ArticleEditBindingModel model)
        {
            var article = await this.articlesService.EditArticleAsync(model);

            SetSuccesfullMessage(EditedSuccessfully, ArticleConst);

            return this.RedirectToAction("Details", new { id = article.Id, slug = article.Slug });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, string slug)
        {
            await this.articlesService.DeleteArticle(id, slug);

            SetSuccesfullMessage(DeletedSuccessfully, ArticleConst);

            return this.RedirectToAction("Index");
        }
    }
}