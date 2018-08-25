namespace MagicOfSewing.Common.Admin.ViewModels
{
    using System;

    public class PostConciseViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }
        
        public DateTime PublishDateTime { get; set; }

        public string Username { get; set; }

        public string UserId { get; set; }

        public string Atatar { get; set; }

        public bool IsApproved { get; set; }
    }
}
