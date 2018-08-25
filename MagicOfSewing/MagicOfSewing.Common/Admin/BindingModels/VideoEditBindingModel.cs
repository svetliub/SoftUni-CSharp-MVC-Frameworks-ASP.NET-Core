namespace MagicOfSewing.Common.Admin.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using static MagicOfSewing.Common.Constants.WebConstants;

    public class VideoEditBindingModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredTitle)]
        public string Title { get; set; }

        [Required(ErrorMessage = RequiredSlug)]
        public string Slug { get; set; }

        [Required(ErrorMessage = RequiredDescription)]
        public string Description { get; set; }

        [Required(ErrorMessage = RequiredYoutube)]
        [Display(Name = "Youtube URL")]
        public string YoutubeId { get; set; }

        [Required(ErrorMessage = RequiredAuthor)]
        [Display(Name = "Author")]
        public string UserId { get; set; }
    }
}
