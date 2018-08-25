namespace MagicOfSewing.Web.Pages.Articles
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using MagicOfSewing.Common.Admin.BindingModels;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Data;
    using MagicOfSewing.Models;
    using MagicOfSewing.Services.Admin.Interfaces;
    using MagicOfSewing.Web.Common;
    using MagicOfSewing.Web.Helpers.Messages;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class DetailsModel : BasePage
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly IAdminPostsService postsService;

        public DetailsModel(MagicOfSewingDbContext dbContext, IMapper mapper, UserManager<User> userManager, IAdminPostsService postsService) 
            : base(dbContext)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.postsService = postsService;
        }

        public ArticleDetailsViewModel Article { get; set; }

        [BindProperty]
        public PostCreationBindingModel PostCreation { get; set; }

        public IEnumerable<PostConciseViewModel> Posts { get; set; }

        public async Task<IActionResult> OnGet(int id, string slug)
        {
            var article = await this.DbContext.Articles
                .Include(a => a.Author)
                .Include(a => a.Posts).ThenInclude(p => p.User)
                .FirstOrDefaultAsync(v => v.Id == id && v.Slug == slug);

            this.Article = this.mapper.Map<ArticleDetailsViewModel>(article);
            this.PostCreation = new PostCreationBindingModel();
            this.Posts = this.mapper.Map<IEnumerable<PostConciseViewModel>>(article.Posts).Where(p => p.IsApproved == true).OrderBy(p => p.PublishDateTime);

            var currentUser = await this.userManager.GetUserAsync(HttpContext.User);

            if (currentUser != null)
            {
                this.TempData["userId"] = currentUser.Id;
            }

            this.TempData["articleId"] = id;
            this.TempData["slug"] = slug;

            return Page();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAdd()
        {
            this.PostCreation.UserId = this.TempData["userId"].ToString();
            this.PostCreation.ArticleId = (int)this.TempData["articleId"];

            var post = await this.postsService.AddPostAsync(this.PostCreation);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Your post is waiting for approval!"
            });

            return RedirectToPage(new { id = this.PostCreation.ArticleId, slug = this.TempData["slug"].ToString() });
        }
    }
}