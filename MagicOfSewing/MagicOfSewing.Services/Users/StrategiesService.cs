namespace MagicOfSewing.Services.Users
{
    using AutoMapper;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Data;
    using MagicOfSewing.Services.Users.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class StrategiesService : BaseEFService, IStrategiesService
    {
        public StrategiesService(MagicOfSewingDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper) { }

        public async Task<IEnumerable<StrategyConciseViewModel>> GetAllStrategiesAsync()
        {
            var strategy = await this.DbContext.Strategies
                .OrderBy(a => a.Priority)
                .ToListAsync();

            var models = this.Mapper.Map<IEnumerable<StrategyConciseViewModel>>(strategy);

            return models;
        }
    }
}
