namespace MagicOfSewing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static MagicOfSewing.Common.Constants.WebConstants;

    public class Video
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredTitle)]
        public string Title { get; set; }

        [Required(ErrorMessage = RequiredSlug)]
        public string Slug { get; set; }

        [Required(ErrorMessage = RequiredDescription)]
        public string Description { get; set; }

        [Required(ErrorMessage = RequiredYoutube)]
        [MinLength(11)]
        [MaxLength(11)]
        public string YoutubeId { get; set; }

        [Required]
        public DateTime PublishDateTime { get; set; }

        public ICollection<Post> Posts { get; set; }

        public string UserId { get; set; }
        public User Author { get; set; }
    }
}
