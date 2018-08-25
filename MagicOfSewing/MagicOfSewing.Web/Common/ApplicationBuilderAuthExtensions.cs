namespace MagicOfSewing.Web.Common
{
    using MagicOfSewing.Common.Constants;
    using MagicOfSewing.Data;
    using MagicOfSewing.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderAuthExtensions
    {
        private const string DefaultFirstAdminPassword = "Stela123";
        private const string DefaultSecondAdminPassword = "Kristiana123";
        private const string DefaultFirstUserPassword = "firstUser123";
        private const string DefaultFirstAdminUsername = "adminStela";
        private const string DefaultSecondAdminUsername = "adminKristiana";
        private const string DefaultFirstUserUsername = "firstUser";
        private const string DefaultFirstAdminEmail = "stela@megicofsewing.com";
        private const string DefaultSecondAdminEmail = "kristiana@megicofsewing.com";
        private const string DefaultFirstUserEmail = "firstuser@fff.fff";

        private static IdentityRole[] roles =
        {
            new IdentityRole("Administrator")
        };

        public static async void SeedDatabase(this IApplicationBuilder app)
        {
            var serviceFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var scope = serviceFactory.CreateScope();

            using (scope)
            {
                var context = scope.ServiceProvider.GetService<MagicOfSewingDbContext>();
                context.Database.Migrate();

                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role.Name))
                    {
                        await roleManager.CreateAsync(role);
                    }
                }

                if (!await context.Users.AnyAsync())
                {
                    var firstUser = new User()
                    {
                        UserName = DefaultFirstUserUsername,
                        Email = DefaultFirstUserEmail,
                        AvatarUrl = "/images/defaultAvatar.jpg"
                    };

                    await userManager.CreateAsync(firstUser, DefaultFirstUserPassword);
                }

                var firstAdmin = await userManager.FindByNameAsync(DefaultFirstAdminUsername);

                if (firstAdmin == null)
                {
                    firstAdmin = new User()
                    {
                        UserName = DefaultFirstAdminUsername,
                        Email = DefaultFirstAdminEmail,
                        AvatarUrl = "/images/Aniston.jpg"
                    };

                    await userManager.CreateAsync(firstAdmin, DefaultFirstAdminPassword);
                    await userManager.AddToRoleAsync(firstAdmin, roles[0].Name);
                }

                var secondAdmin = await userManager.FindByNameAsync(DefaultSecondAdminUsername);

                if (secondAdmin == null)
                {
                    secondAdmin = new User()
                    {
                        UserName = DefaultSecondAdminUsername,
                        Email = DefaultSecondAdminEmail,
                        AvatarUrl = "/images/Lopez.jpg"
                    };

                    await userManager.CreateAsync(secondAdmin, DefaultSecondAdminPassword);
                    await userManager.AddToRoleAsync(secondAdmin, roles[0].Name);
                }

                if (!await context.ArticleCategories.AnyAsync())
                {
                    ArticleCategory[] categories =
                    {
                        new ArticleCategory(){ Name = WebConstants.DefaultModaAndStyleArticleCategory },
                        new ArticleCategory(){ Name = WebConstants.DefaultHowToArticleCategory }
                    };

                    await context.ArticleCategories.AddRangeAsync(categories);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
