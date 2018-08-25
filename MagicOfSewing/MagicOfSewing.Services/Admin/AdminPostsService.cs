namespace MagicOfSewing.Services.Admin
{
    using AutoMapper;
    using MagicOfSewing.Common.Admin.BindingModels;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Common.Validation;
    using MagicOfSewing.Data;
    using MagicOfSewing.Models;
    using MagicOfSewing.Services.Admin.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminPostsService : BaseEFService, IAdminPostsService
    {
        public AdminPostsService(MagicOfSewingDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper) { }

        public async Task<Post> AddPostAsync(PostCreationBindingModel model)
        {
            Validator.EnsureNotNull(model, ValidationConstants.PostDefinedMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Content, ValidationConstants.PostContentMessage);

            var post = this.Mapper.Map<Post>(model);
            await this.DbContext.Posts.AddAsync(post);
            await this.DbContext.SaveChangesAsync();

            return post;
        }
               
        public async Task<IEnumerable<PostConciseViewModel>> GetAllPostsAsync()
        {
            var posts = await this.DbContext.Posts
                .Include(p => p.User)
                .OrderBy(p => p.IsApproved == true)
                .ToListAsync();

            var models = this.Mapper.Map<IEnumerable<PostConciseViewModel>>(posts);

            return models;
        }

        public async Task ApprovePost(int id)
        {
            var post = await GetPost(id);
            post.IsApproved = true;

            await this.DbContext.SaveChangesAsync();
        }

        public async Task UnApprovePost(int id)
        {
            var post = await GetPost(id);
            post.IsApproved = false;

            await this.DbContext.SaveChangesAsync();
        }

        public async Task DeletePost(int id)
        {
            var post = await GetPost(id);
            this.DbContext.Posts.Remove(post);

            await this.DbContext.SaveChangesAsync();
        }

        private async Task<Post> GetPost(int id)
        {
            return await this.DbContext.Posts.FindAsync(id);
        }        
    }
}
