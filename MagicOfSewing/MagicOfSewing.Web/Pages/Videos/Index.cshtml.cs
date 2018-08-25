namespace MagicOfSewing.Web.Pages.Videos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Data;
    using MagicOfSewing.Web.Common;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using static MagicOfSewing.Common.Constants.WebConstants;

    public class IndexModel : BasePage
    {
        private readonly IMapper mapper;

        public IndexModel(MagicOfSewingDbContext dbContext, IMapper mapper)
            : base(dbContext)
        {
            this.mapper = mapper;
            this.VideoViewModels = new List<VideoConciseViewModel>();
            this.Models = new PaginatedList<VideoConciseViewModel>(new List<VideoConciseViewModel>(), 1, 1);
        }             

        public IEnumerable<VideoConciseViewModel> VideoViewModels { get; set; }

        public PaginatedList<VideoConciseViewModel> Models { get; set; }

        public void OnGet(int pageIndex = 1)
        {
            pageIndex = Math.Max(1, pageIndex);

            var videos = this.DbContext.Videos
                .Include(v => v.Author)
                .OrderByDescending(v => v.PublishDateTime)
                .ToList();

            this.VideoViewModels = this.mapper.Map<IEnumerable<VideoConciseViewModel>>(videos);

            var totalPages = Math.Max(1, (int)Math.Ceiling(videos.Count() / (double)UsersVideosCountOnPage));
            pageIndex = Math.Min(pageIndex, totalPages);

            var videosToShow = this.VideoViewModels
                .Skip((pageIndex - 1) * UsersVideosCountOnPage)
                .Take(UsersVideosCountOnPage)
                .ToList();

            this.Models = new PaginatedList<VideoConciseViewModel>(videosToShow, pageIndex, totalPages);
        }
    }
}