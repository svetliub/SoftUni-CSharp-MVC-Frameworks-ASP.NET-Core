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

    public class AdminArticlesService : BaseEFService, IAdminArticlesService
    {
        public AdminArticlesService(MagicOfSewingDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<Article> AddArticleAsync(ArticleCreationBindingModel model)
        {
            Validator.EnsureNotNull(model, ValidationConstants.ArticleDefinedMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Title, ValidationConstants.ArticleTitleMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Slug, ValidationConstants.ArticleSlugMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Content, ValidationConstants.ArticleContentMessage);
            Validator.EnsureStringNotNullOrEmpty(model.PublishDateTime.ToString(), ValidationConstants.ArticleDateMessage);
            Validator.EnsureStringNotNullOrEmpty(model.AuthorId, ValidationConstants.ArticleAuthorMessage);
            Validator.EnsureStringNotNullOrEmpty(model.ArticleCategoryId.ToString(), ValidationConstants.ArticleCategoryMessage);

            var article = this.Mapper.Map<Article>(model);
            await this.DbContext.Articles.AddAsync(article);
            await this.DbContext.SaveChangesAsync();

            return article;
        }

        public async Task<IEnumerable<CategoryConciseViewModel>> GetArticleCategoriesAsync()
        {
            var categories = await this.DbContext.ArticleCategories.ToListAsync();

            var models = this.Mapper.Map<IEnumerable<CategoryConciseViewModel>>(categories);

            return models;
        }

        public async Task<ArticleDetailsViewModel> GetArticleDetailsAsync(int id, string slug)
        {
            Article article = await GetArticle(id, slug);

            var model = this.Mapper.Map<ArticleDetailsViewModel>(article);

            return model;
        }

        public async Task<IEnumerable<ArticleConciseViewModel>> GetAllArticlesAsync()
        {
            var articles = await this.DbContext.Articles
                .Include(a => a.Author)
                .OrderByDescending(a => a.PublishDateTime)
                .ToListAsync();

            var models = this.Mapper.Map<IEnumerable<ArticleConciseViewModel>>(articles);

            return models;
        }

        public async Task<ArticleEditBindingModel> GetArticleEditAsync(int id, string slug)
        {
            Article article = await GetArticle(id, slug);

            var model = this.Mapper.Map<ArticleEditBindingModel>(article);

            return model;
        }

        public async Task<Article> EditArticleAsync(ArticleEditBindingModel model)
        {
            Validator.EnsureNotNull(model, ValidationConstants.ArticleDefinedMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Title, ValidationConstants.ArticleTitleMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Slug, ValidationConstants.ArticleSlugMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Content, ValidationConstants.ArticleContentMessage);
            Validator.EnsureStringNotNullOrEmpty(model.AuthorId, ValidationConstants.ArticleAuthorMessage);
            Validator.EnsureStringNotNullOrEmpty(model.ArticleCategoryId.ToString(), ValidationConstants.ArticleCategoryMessage);

            var dbArticle = this.DbContext.Articles.Find(model.Id);

            dbArticle.ArticleCategoryId = model.ArticleCategoryId;
            dbArticle.AuthorId = model.AuthorId;
            dbArticle.Content = model.Content;
            dbArticle.Title = model.Title;
            dbArticle.Slug = model.Slug;

            await this.DbContext.SaveChangesAsync();

            return dbArticle;
        }

        public async Task DeleteArticle(int id, string slug)
        {
            var article = await GetArticle(id, slug);
            this.DbContext.Articles.Remove(article);

            await this.DbContext.SaveChangesAsync();
        }

        private async Task<Article> GetArticle(int id, string slug)
        {
            var article = await this.DbContext.Articles
                .Include(a => a.Author)
                .FirstOrDefaultAsync(c => c.Id == id && c.Slug == slug);
            return article;
        }        
    }
}
