using MagicOfSewing.Common.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagicOfSewing.Services.Users.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<UserConciseViewModel>> GetAuthorsAsync();
    }
}
