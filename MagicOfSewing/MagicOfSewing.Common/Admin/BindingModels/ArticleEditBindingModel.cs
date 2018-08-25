namespace MagicOfSewing.Common.Admin.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using static MagicOfSewing.Common.Constants.WebConstants;

    public class ArticleEditBindingModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredTitle)]
        [MinLength(4)]
        public string Title { get; set; }

        [Required(ErrorMessage = RequiredSlug)]
        public string Slug { get; set; }

        [Required(ErrorMessage = RequiredContent)]
        [MinLength(10)]
        public string Content { get; set; }

        [Required(ErrorMessage = RequiredAuthor)]
        [Display(Name = "Author")]
        public string AuthorId { get; set; }

        [Required(ErrorMessage = RequiredCategory)]
        [Display(Name = "Category")]
        public int ArticleCategoryId { get; set; }
    }
}
