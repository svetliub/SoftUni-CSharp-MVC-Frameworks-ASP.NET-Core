namespace MagicOfSewing.Common.Admin.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using static MagicOfSewing.Common.Constants.WebConstants;

    public class StrategyCreationBindingModel
    {
        [Required(ErrorMessage = RequiredTitle)]
        public string Title { get; set; }

        [Required(ErrorMessage = RequiredSlug)]
        public string Slug { get; set; }

        [Required(ErrorMessage = RequiredContent)]
        public string Content { get; set; }

        [Required(ErrorMessage = RequiredPriority)]
        public int Priority { get; set; }
    }
}
