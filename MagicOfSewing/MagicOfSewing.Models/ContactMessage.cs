namespace MagicOfSewing.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static MagicOfSewing.Common.Constants.WebConstants;

    public class ContactMessage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredName)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequiredEmail)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = RequiredSubject)]
        public string Subject { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        public string Message { get; set; }

        public DateTime SendTime { get; set; } = DateTime.Now;

        public bool IsAnswered { get; set; } = false;
    }
}
