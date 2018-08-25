namespace MagicOfSewing.Web.Pages.Home
{
    using System.ComponentModel.DataAnnotations;
    using MagicOfSewing.Data;
    using MagicOfSewing.Models;
    using Microsoft.AspNetCore.Mvc;

    public class ContactsModel : BasePage
    {
        public ContactsModel(MagicOfSewingDbContext dbContext)
            : base(dbContext) { }

        [BindProperty]
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Subject is required!")]
        public string Subject { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Description is required!")]
        public string Message { get; set; }

        public IActionResult OnPostSend()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var message = new ContactMessage()
            {
                Name = this.Name,
                Email = this.Email,
                Subject = this.Subject,
                Message = this.Message
            };

            this.DbContext.ContactMessages.Add(message);
            this.DbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}