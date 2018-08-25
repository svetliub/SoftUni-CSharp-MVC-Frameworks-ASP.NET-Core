namespace MagicOfSewing.Services.Admin
{
    using AutoMapper;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Data;
    using MagicOfSewing.Services.Admin.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminMessagesServices : BaseEFService, IAdminMessagesServices
    {
        public AdminMessagesServices(MagicOfSewingDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper) { }
               
        public async Task<IEnumerable<MessageConciseViewModel>> GetAllMessagesAsync()
        {
            var messages = await this.DbContext.ContactMessages
                .OrderByDescending(m => m.SendTime)
                .ToListAsync();

            var models = this.Mapper.Map<IEnumerable<MessageConciseViewModel>>(messages);

            return models;
        }

        public async Task<MessageDetailsViewModel> GetMessageDetailsAsync(int id)
        {
            var message = await this.DbContext.ContactMessages
                .FirstOrDefaultAsync(c => c.Id == id);

            var model = this.Mapper.Map<MessageDetailsViewModel>(message);

            return model;
        }

        public async Task AnswerMessage(int id)
        {
            var message = await GetMessage(id);
            message.IsAnswered = true;

            await this.DbContext.SaveChangesAsync();
        }

        public async Task DeleteMessage(int id)
        {
            var message = await GetMessage(id);
            this.DbContext.ContactMessages.Remove(message);

            await this.DbContext.SaveChangesAsync();
        }

        private async Task<Models.ContactMessage> GetMessage(int id)
        {
            return await this.DbContext.ContactMessages.FindAsync(id);
        }
    }
}
