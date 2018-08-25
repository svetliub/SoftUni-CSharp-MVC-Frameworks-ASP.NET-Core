namespace MagicOfSewing.Web.Pages
{
    using MagicOfSewing.Data;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class BasePage : PageModel
    {
        public MagicOfSewingDbContext DbContext;

        public BasePage(MagicOfSewingDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
    }
}
