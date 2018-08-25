namespace MagicOfSewing.Services.Admin.Interfaces
{
    using MagicOfSewing.Common.Admin.BindingModels;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminPostsService
    {
        Task<Post> AddPostAsync(PostCreationBindingModel model);

        Task<IEnumerable<PostConciseViewModel>> GetAllPostsAsync();

        Task ApprovePost(int id);

        Task UnApprovePost(int id);

        Task DeletePost(int id);
    }
}
