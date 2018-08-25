namespace MagicOfSewing.Services.Admin.Interfaces
{
    using MagicOfSewing.Common.Admin.BindingModels;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminArticlesService
    {
        Task<IEnumerable<ArticleConciseViewModel>> GetAllArticlesAsync();

        Task<IEnumerable<CategoryConciseViewModel>> GetArticleCategoriesAsync();
        
        Task<Article> AddArticleAsync(ArticleCreationBindingModel model);

        Task<ArticleDetailsViewModel> GetArticleDetailsAsync(int id, string slug);

        Task<ArticleEditBindingModel> GetArticleEditAsync(int id, string slug);

        Task<Article> EditArticleAsync(ArticleEditBindingModel model);

        Task DeleteArticle(int id, string slug);
    }
}
