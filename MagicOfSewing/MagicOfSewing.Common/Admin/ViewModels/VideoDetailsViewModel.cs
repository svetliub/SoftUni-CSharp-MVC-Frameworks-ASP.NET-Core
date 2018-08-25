namespace MagicOfSewing.Common.Admin.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class VideoDetailsViewModel
    {
        public int Id { get; set; }

        public string YoutubeId { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public string AvatarUrl { get; set; }

        public DateTime PublishDateTime { get; set; }

        //public ICollection<PostConciseViewModel> Posts { get; set; }
    }
}
