namespace MagicOfSewing.Services.Admin.Interfaces
{
    using MagicOfSewing.Common.Admin.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminMessagesServices
    {
        Task<IEnumerable<MessageConciseViewModel>> GetAllMessagesAsync();
        
        Task<MessageDetailsViewModel> GetMessageDetailsAsync(int id);

        Task AnswerMessage(int id);

        Task DeleteMessage(int id);
    }
}
