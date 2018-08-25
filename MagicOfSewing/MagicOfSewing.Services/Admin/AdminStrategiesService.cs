namespace MagicOfSewing.Services.Admin
{
    using AutoMapper;
    using MagicOfSewing.Common.Admin.BindingModels;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Common.Validation;
    using MagicOfSewing.Data;
    using MagicOfSewing.Models;
    using MagicOfSewing.Services.Admin.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminStrategiesService : BaseEFService, IAdminStrategiesService
    {
        public AdminStrategiesService(MagicOfSewingDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper) { }

        public async Task<Strategy> AddStrategyAsync(StrategyCreationBindingModel model)
        {
            Validator.EnsureNotNull(model, ValidationConstants.StrategyDefinedMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Title, ValidationConstants.StrategyTitleMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Slug, ValidationConstants.StrategySlugMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Content, ValidationConstants.StrategyContentMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Priority.ToString(), ValidationConstants.StrategyPriorityMessage);

            var strategy = this.Mapper.Map<Strategy>(model);
            await this.DbContext.Strategies.AddAsync(strategy);
            await this.DbContext.SaveChangesAsync();

            return strategy;
        }
                  
        public async Task<IEnumerable<StrategyConciseViewModel>> GetAllStrategiesAsync()
        {
            var strategies = await this.DbContext.Strategies
                .OrderBy(s => s.Priority)
                .ToListAsync();

            var models = this.Mapper.Map<IEnumerable<StrategyConciseViewModel>>(strategies);

            return models;
        }

        public async Task<StrategyDetailsViewModel> GetStrategyDetailsAsync(int id, string slug)
        {
            var strategy = await GetStrategy(id, slug);

            var model = this.Mapper.Map<StrategyDetailsViewModel>(strategy);

            return model;
        }

        public async Task<StrategyEditBindingModel> GetStrategyEditAsync(int id, string slug)
        {
            var strategy = await GetStrategy(id, slug);

            var model = this.Mapper.Map<StrategyEditBindingModel>(strategy);

            return model;
        }

        public async Task<Strategy> EditStrategyAsync(StrategyEditBindingModel model)
        {
            Validator.EnsureNotNull(model, ValidationConstants.StrategyDefinedMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Title, ValidationConstants.StrategyTitleMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Slug, ValidationConstants.StrategySlugMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Content, ValidationConstants.StrategyContentMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Priority.ToString(), ValidationConstants.StrategyPriorityMessage);

            var dbStrategy = this.DbContext.Strategies.Find(model.Id);

            dbStrategy.Priority = model.Priority;
            dbStrategy.Content = model.Content;
            dbStrategy.Title = model.Title;
            dbStrategy.Slug = model.Slug;

            await this.DbContext.SaveChangesAsync();

            return dbStrategy;
        }

        public async Task DeleteStrategy(int id, string slug)
        {
            var strategy = await GetStrategy(id, slug);
            this.DbContext.Strategies.Remove(strategy);

            await this.DbContext.SaveChangesAsync();
        }
        
        private async Task<Strategy> GetStrategy(int id, string slug)
        {
            var strategy = await this.DbContext.Strategies
                .FirstOrDefaultAsync(c => c.Id == id && c.Slug == slug);

            return strategy;
        }
    }
}
