namespace MagicOfSewing.Common.Admin.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static MagicOfSewing.Common.Constants.WebConstants;

    public class PostCreationBindingModel
    {
        [Required(ErrorMessage = RequiredContent)]
        public string Content { get; set; }

        public Nullable<int> VideoId { get; set; } = null;

        public Nullable<int> ArticleId { get; set; } = null;

        public string UserId { get; set; }

        public DateTime PublishDateTime { get; set; } = DateTime.Now;

        public bool IsApproved { get; set; } = false;
    }
}
