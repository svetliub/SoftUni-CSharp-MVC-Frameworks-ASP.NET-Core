namespace MagicOfSewing.Common.Admin.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using static MagicOfSewing.Common.Constants.WebConstants;

    public class FabricEditBindingModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredName)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequiredSlug)]
        public string Slug { get; set; }

        [Required(ErrorMessage = RequiredDescription)]
        public string Description { get; set; }

        [Required(ErrorMessage = RequiredImage)]
        public string ImageUrl { get; set; }
    }
}
