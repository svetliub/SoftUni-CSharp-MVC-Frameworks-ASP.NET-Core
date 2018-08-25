namespace MagicOfSewing.Services.Admin.Interfaces
{
    using MagicOfSewing.Common.Admin.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminUsersService
    {
        Task<IEnumerable<AuthorConciseViewModel>> GetAuthorsAsync();

        Task<IEnumerable<UserConciseViewModel>> GetAllUsersAsync();

        Task<UserDetailsViewModel> GetUserDetailsAsync(string id);

        Task DeleteUser(string id);
    }
}
