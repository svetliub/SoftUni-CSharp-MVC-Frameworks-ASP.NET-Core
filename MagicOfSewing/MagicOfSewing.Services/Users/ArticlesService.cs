namespace MagicOfSewing.Services.Users
{
    using AutoMapper;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Common.Constants;
    using MagicOfSewing.Data;
    using MagicOfSewing.Services.Users.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ArticlesService : BaseEFService, IArticlesService
    {
        public ArticlesService(MagicOfSewingDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper) { }

        public async Task<IEnumerable<ArticleConciseViewModel>> GetAllHowToArticlesAsync()
        {
            var articles = await this.DbContext.Articles
                .Include(a => a.Author)
                .Where(a => a.Category.Name == WebConstants.DefaultHowToArticleCategory)
                .OrderByDescending(a => a.PublishDateTime)
                .ToListAsync();

            var models = this.Mapper.Map<IEnumerable<ArticleConciseViewModel>>(articles);

            return models;
        }

        public async Task<IEnumerable<ArticleConciseViewModel>> GetAllModaAndStyleArticlesAsync()
        {
            var articles = await this.DbContext.Articles
                .Include(a => a.Author)
                .Where(a => a.Category.Name == WebConstants.DefaultModaAndStyleArticleCategory)
                .OrderByDescending(a => a.PublishDateTime)
                .ToListAsync();

            var models = this.Mapper.Map<IEnumerable<ArticleConciseViewModel>>(articles);

            return models;
        }

        public async Task<IEnumerable<ArticleConciseViewModel>> GetArticlesByAsync(string username)
        {
            var articles = await this.DbContext.Articles
                .Include(a => a.Author)
                .Where(a => a.Author.UserName == username)
                .OrderByDescending(a => a.PublishDateTime)
                .ToListAsync();

            var models = this.Mapper.Map<IEnumerable<ArticleConciseViewModel>>(articles);

            return models;
        }
    }
}
