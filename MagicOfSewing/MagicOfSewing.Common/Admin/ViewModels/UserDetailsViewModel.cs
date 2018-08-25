namespace MagicOfSewing.Common.Admin.ViewModels
{
    using System.Collections.Generic;

    public class UserDetailsViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string AvatarUrl { get; set; }

        public string Email { get; set; }

        public ICollection<PostConciseViewModel> Posts { get; set; }
    }
}
