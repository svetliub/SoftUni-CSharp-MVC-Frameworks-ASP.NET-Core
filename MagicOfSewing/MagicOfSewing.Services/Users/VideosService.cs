namespace MagicOfSewing.Services.Users
{
    using AutoMapper;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Data;
    using MagicOfSewing.Services.Users.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class VideosService : BaseEFService, IVideosService
    {
        public VideosService(MagicOfSewingDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper) { }

        public async Task<IEnumerable<VideoConciseViewModel>> GetVideosByAsync(string username)
        {
            var videos = await this.DbContext.Videos
                .Include(a => a.Author)
                .Where(a => a.Author.UserName == username)
                .OrderByDescending(a => a.PublishDateTime)
                .ToListAsync();

            var models = this.Mapper.Map<IEnumerable<VideoConciseViewModel>>(videos);

            return models;
        }
    }
}
