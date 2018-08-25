namespace MagicOfSewing.Common.Admin.ViewModels
{
    using System;

    public class MessageDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public DateTime SendTime { get; set; }
    }
}
