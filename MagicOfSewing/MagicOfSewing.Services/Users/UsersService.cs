namespace MagicOfSewing.Services.Users
{
    using AutoMapper;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Common.Constants;
    using MagicOfSewing.Data;
    using MagicOfSewing.Models;
    using MagicOfSewing.Services.Users.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UsersService : BaseEFService, IUsersService
    {
        private readonly UserManager<User> userManager;

        public UsersService(MagicOfSewingDbContext dbContext, IMapper mapper, UserManager<User> userManager)
            : base(dbContext, mapper)
        {
            this.userManager = userManager;
        }

        public async Task<IEnumerable<UserConciseViewModel>> GetAuthorsAsync()
        {
            var users = await this.userManager.GetUsersInRoleAsync(WebConstants.AdminRole);

            var authors = this.Mapper.Map<IEnumerable<UserConciseViewModel>>(users).OrderByDescending(a => a.UserName);

            return authors;
        }
    }
}
