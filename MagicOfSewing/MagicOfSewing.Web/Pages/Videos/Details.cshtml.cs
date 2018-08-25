namespace MagicOfSewing.Web.Pages.Videos
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
               
        public VideoDetailsViewModel Gosho { get; set; }

        [BindProperty]
        public PostCreationBindingModel PostCreation { get; set; }

        public IEnumerable<PostConciseViewModel> Posts { get; set; }

        public async Task<IActionResult> OnGet(int id, string slug)
        {
            var video = await this.DbContext.Videos
                .Include(a => a.Author)
                .Include(a => a.Posts).ThenInclude(p => p.User)
                .FirstOrDefaultAsync(v => v.Id == id && v.Slug == slug);
                      
            this.Gosho = this.mapper.Map<VideoDetailsViewModel>(video);
            this.PostCreation = new PostCreationBindingModel();
            this.Posts = this.mapper.Map<IEnumerable<PostConciseViewModel>>(video.Posts).Where(p => p.IsApproved == true).OrderBy(p => p.PublishDateTime);
            
            var currentUser = await this.userManager.GetUserAsync(HttpContext.User);
            
            if(currentUser != null)
            {
                this.TempData["userId"] = currentUser.Id;
            }

            this.TempData["videoId"] = id;
            this.TempData["slug"] = slug;

            return Page();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAdd()
        {
            this.PostCreation.UserId = this.TempData["userId"].ToString();
            this.PostCreation.VideoId = (int)this.TempData["videoId"];

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            var post = await this.postsService.AddPostAsync(this.PostCreation);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Your post is waiting for approval!"
            });

            return RedirectToPage(new { id = this.PostCreation.VideoId, slug = this.TempData["slug"].ToString() });
        }
    }
}