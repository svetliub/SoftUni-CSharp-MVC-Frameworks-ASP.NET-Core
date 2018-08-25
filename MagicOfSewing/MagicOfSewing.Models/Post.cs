namespace MagicOfSewing.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static MagicOfSewing.Common.Constants.WebConstants;

    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredContent)]
        public string Content { get; set; }
                
        public int? VideoId { get; set; }
        public Video Video { get; set; }

        public int? ArticleId { get; set; }
        public Article Article { get; set; }
                
        public string UserId { get; set; }
        public User User { get; set; }

        public DateTime PublishDateTime { get; set; }

        public bool IsApproved { get; set; } = false;
    }
}
