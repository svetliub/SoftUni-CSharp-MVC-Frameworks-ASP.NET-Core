namespace MagicOfSewing.Services.Admin.Interfaces
{
    using MagicOfSewing.Common.Admin.BindingModels;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminVideosService
    {
        Task<IEnumerable<VideoConciseViewModel>> GetAllVideosAsync();

        Task<VideoDetailsViewModel> GetVideoDetailsAsync(int id, string slug);

        Task<Video> AddVideoAsync(VideoCreationBindingModel model);
                
        Task<VideoEditBindingModel> GetVideoEditAsync(int id, string slug);

        Task<Video> EditVideoAsync(VideoEditBindingModel model);

        Task DeleteVideo(int id, string slug);
    }
}
