namespace MagicOfSewing.Services.Users.Interfaces
{
    using MagicOfSewing.Common.Admin.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticlesService
    {
        Task<IEnumerable<ArticleConciseViewModel>> GetAllHowToArticlesAsync();

        Task<IEnumerable<ArticleConciseViewModel>> GetAllModaAndStyleArticlesAsync();

        Task<IEnumerable<ArticleConciseViewModel>> GetArticlesByAsync(string username);
    }
}
