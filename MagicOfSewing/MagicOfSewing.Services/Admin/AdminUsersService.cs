using AutoMapper;
using MagicOfSewing.Common.Admin.ViewModels;
using MagicOfSewing.Common.Constants;
using MagicOfSewing.Data;
using MagicOfSewing.Models;
using MagicOfSewing.Services.Admin.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagicOfSewing.Services.Admin
{
    public class AdminUsersService : BaseEFService, IAdminUsersService
    {
        private readonly UserManager<User> userManager;

        public AdminUsersService(MagicOfSewingDbContext dbContext, IMapper mapper, UserManager<User> userManager) 
            : base(dbContext, mapper)
        {
            this.userManager = userManager;
        }

        //TODO
        public async Task<IEnumerable<UserConciseViewModel>> GetAllUsersAsync()
        {
            var users = await this.userManager.Users.ToListAsync();

            var allUsers = this.Mapper.Map<IEnumerable<UserConciseViewModel>>(users);

            return allUsers;
        }

        public async Task<IEnumerable<AuthorConciseViewModel>> GetAuthorsAsync()
        {
            var users = await this.userManager.GetUsersInRoleAsync(WebConstants.AdminRole);

            var authors = this.Mapper.Map<IEnumerable<AuthorConciseViewModel>>(users);

            return authors;
        }

        public async Task<UserDetailsViewModel> GetUserDetailsAsync(string id)
        {
            var user = await this.DbContext.Users
                .Include(u => u.Posts)
                .FirstOrDefaultAsync(u => u.Id == id);

            var userModel = this.Mapper.Map<UserDetailsViewModel>(user);

            return userModel;
        }

        public async Task DeleteUser(string id)
        {
            var user = await this.DbContext.Users
                .Include(u => u.Posts)
                .FirstOrDefaultAsync(u => u.Id == id);

            this.DbContext.Posts.RemoveRange(user.Posts);
            this.DbContext.Users.Remove(user);

            await this.DbContext.SaveChangesAsync();
        }
    }
}
