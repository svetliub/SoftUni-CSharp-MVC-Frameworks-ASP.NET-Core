namespace MagicOfSewing.Common.Admin.ViewModels
{
    using System;

    public class VideoConciseViewModel
    {
        public int Id { get; set; }

        public string YoutubeId { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Author { get; set; }

        public DateTime PublishDateTime { get; set; }
    }
}
