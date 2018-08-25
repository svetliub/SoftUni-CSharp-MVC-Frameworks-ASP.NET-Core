namespace MagicOfSewing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static MagicOfSewing.Common.Constants.WebConstants;

    public class Article
    {
        public Article()
        {
            this.Posts = new List<Post>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = RequiredTitle)]
        [MinLength(4)]
        public string Title { get; set; }

        [Required(ErrorMessage = RequiredSlug)]
        public string Slug { get; set; }

        [Required(ErrorMessage = RequiredContent)]
        [MinLength(10)]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }
        public User Author { get; set; }

        [Required]
        public int ArticleCategoryId { get; set; }
        public ArticleCategory Category { get; set; }

        [Required]
        public DateTime PublishDateTime { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
