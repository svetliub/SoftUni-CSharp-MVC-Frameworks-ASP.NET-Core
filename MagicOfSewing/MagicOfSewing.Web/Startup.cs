namespace MagicOfSewing.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MagicOfSewing.Data;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Routing;
    using AutoMapper;
    using System;
    using MagicOfSewing.Models;
    using MagicOfSewing.Web.Common;
    using MagicOfSewing.Services.Admin.Interfaces;
    using MagicOfSewing.Services.Admin;
    using MagicOfSewing.Services.Users.Interfaces;
    using MagicOfSewing.Services.Users;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<MagicOfSewingDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("MagicOfSewingConnection"),
                    dbOptions => dbOptions.MigrationsAssembly("MagicOfSewing.Data")));

            services.AddIdentity<User, IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<MagicOfSewingDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password = new PasswordOptions()
                {
                    RequiredLength = 4,
                    RequiredUniqueChars = 1,
                    RequireDigit = false,
                    RequireLowercase = true,
                    RequireNonAlphanumeric = false,
                    RequireUppercase = false
                };

                //options.SignIn.RequireConfirmedEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 4;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            });

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            services.AddAutoMapper();

            RegisterServiceLayer(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.SeedDatabase();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}/{slug?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}/{slug?}");
            });
        }

        private static void RegisterServiceLayer(IServiceCollection services)
        {
            services.AddScoped<IAdminArticlesService, AdminArticlesService>();
            services.AddScoped<IAdminVideosService, AdminVideosService>();
            services.AddScoped<IAdminUsersService, AdminUsersService>();
            services.AddScoped<IArticlesService, ArticlesService>();
            services.AddScoped<IAdminMessagesServices, AdminMessagesServices>();
            services.AddScoped<IAdminFabricsService, AdminFabricsService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IAdminStrategiesService, AdminStrategiesService>();
            services.AddScoped<IStrategiesService, StrategiesService>();
            services.AddScoped<IAdminPostsService, AdminPostsService>();
            services.AddScoped<IVideosService, VideosService>();
        }
    }
}
