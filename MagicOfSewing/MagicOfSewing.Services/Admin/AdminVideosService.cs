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

    public class AdminVideosService : BaseEFService, IAdminVideosService
    {
        public AdminVideosService(MagicOfSewingDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper) { }

        public async Task<Video> AddVideoAsync(VideoCreationBindingModel model)
        {
            Validator.EnsureNotNull(model, ValidationConstants.VideoDefinedMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Title, ValidationConstants.VideoTitleMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Slug, ValidationConstants.VideoSlugMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Description, ValidationConstants.VideoDescriptionMessage);
            Validator.EnsureStringNotNullOrEmpty(model.PublishDateTime.ToString(), ValidationConstants.VideoDateMessage);
            Validator.EnsureStringNotNullOrEmpty(model.UserId, ValidationConstants.VideoAuthorMessage);
            Validator.EnsureStringNotNullOrEmpty(model.YoutubeId, ValidationConstants.VideoYoutubeMessage);

            var video = this.Mapper.Map<Video>(model);

            string youtubeId = null;

            if (model.YoutubeId.Contains("youtube.com"))
            {
                youtubeId = model.YoutubeId.Split("v=").Last().Substring(0, 11);
            }
            else if (model.YoutubeId.Contains("youtu.be"))
            {
                youtubeId = model.YoutubeId.Split("/").Last().Substring(0, 11);
            }

            video.YoutubeId = youtubeId;
                       
            await this.DbContext.Videos.AddAsync(video);
            await this.DbContext.SaveChangesAsync();

            return video;
        }

        public async Task<VideoDetailsViewModel> GetVideoDetailsAsync(int id, string slug)
        {
            var video = await GetVideo(id, slug);

            var model = this.Mapper.Map<VideoDetailsViewModel>(video);

            return model;
        }

        public async Task<IEnumerable<VideoConciseViewModel>> GetAllVideosAsync()
        {
            var videos = await this.DbContext.Videos
                .Include(v => v.Author)
                .OrderByDescending(a => a.PublishDateTime)
                .ToListAsync();

            var models = this.Mapper.Map<IEnumerable<VideoConciseViewModel>>(videos);

            return models;
        }

        public async Task<VideoEditBindingModel> GetVideoEditAsync(int id, string slug)
        {
            var video = await GetVideo(id, slug);

            var model = this.Mapper.Map<VideoEditBindingModel>(video);

            return model;
        }

        public async Task<Video> EditVideoAsync(VideoEditBindingModel model)
        {
            Validator.EnsureNotNull(model, ValidationConstants.VideoDefinedMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Title, ValidationConstants.VideoTitleMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Slug, ValidationConstants.VideoSlugMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Description, ValidationConstants.VideoDescriptionMessage);
            Validator.EnsureStringNotNullOrEmpty(model.UserId, ValidationConstants.VideoAuthorMessage);
            Validator.EnsureStringNotNullOrEmpty(model.YoutubeId, ValidationConstants.VideoYoutubeMessage);

            var dbVideo = this.DbContext.Videos.Find(model.Id);

            var youtubeId = model.YoutubeId;

            if (model.YoutubeId.Contains("youtube.com"))
            {
                youtubeId = model.YoutubeId.Split("v=").Last().Substring(0, 11);
            }
            else if (model.YoutubeId.Contains("youtu.be"))
            {
                youtubeId = model.YoutubeId.Split("/").Last().Substring(0, 11);
            }

            dbVideo.YoutubeId = youtubeId;
            dbVideo.UserId = model.UserId;
            dbVideo.Description = model.Description;
            dbVideo.Title = model.Title;
            dbVideo.Slug = model.Slug;

            await this.DbContext.SaveChangesAsync();

            return dbVideo;
        }

        public async Task DeleteVideo(int id, string slug)
        {
            var video = await GetVideo(id, slug);
            this.DbContext.Videos.Remove(video);

            await this.DbContext.SaveChangesAsync();
        }

        private async Task<Video> GetVideo(int id, string slug)
        {
            var video = await this.DbContext.Videos
                .Include(a => a.Author)
                .FirstOrDefaultAsync(v => v.Id == id && v.Slug == slug);

            return video;
        }
    }
}
