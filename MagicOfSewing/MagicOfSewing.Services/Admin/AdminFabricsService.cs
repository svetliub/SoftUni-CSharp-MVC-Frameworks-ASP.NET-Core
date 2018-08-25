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
    using Validator = Common.Validation.Validator;

    public class AdminFabricsService : BaseEFService, IAdminFabricsService
    {
        public AdminFabricsService(MagicOfSewingDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper) { }

        public async Task<Fabric> AddFabricAsync(FabricCreationBindingModel model)
        {
            Validator.EnsureNotNull(model, ValidationConstants.FabricDefinedMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Name, ValidationConstants.FabricNameMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Slug, ValidationConstants.FabricSlugMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Description, ValidationConstants.FabricDescriptionMessage);
            Validator.EnsureStringNotNullOrEmpty(model.ImageUrl, ValidationConstants.FabricImageUrlMessage);

            var fabric = this.Mapper.Map<Fabric>(model);
                        
            await this.DbContext.Fabrics.AddAsync(fabric);
            await this.DbContext.SaveChangesAsync();

            return fabric;
        }

        public async Task DeleteFabric(int id)
        {
            var fabric = await this.DbContext.Fabrics.FindAsync(id);
            this.DbContext.Fabrics.Remove(fabric);

            await this.DbContext.SaveChangesAsync();
        }
                
        public async Task<IEnumerable<FabricConciseViewModel>> GetAllFabricsAsync()
        {
            var fabrics = await this.DbContext.Fabrics
                .OrderBy(m => m.Name)
                .ToListAsync();

            var models = this.Mapper.Map<IEnumerable<FabricConciseViewModel>>(fabrics);

            return models;
        }

        public async Task<FabricDetailsViewModel> GetFabricDetailsAsync(int id, string slug)
        {
            var fabric = await this.DbContext.Fabrics
                .FirstOrDefaultAsync(c => c.Id == id && c.Slug == slug);

            var model = this.Mapper.Map<FabricDetailsViewModel>(fabric);

            return model;
        }

        public async Task<FabricEditBindingModel> GetFabricEditAsync(int id)
        {
            var fabric = await this.DbContext.Fabrics.FindAsync(id);

            var model = this.Mapper.Map<FabricEditBindingModel>(fabric);

            return model;
        }

        public async Task<Fabric> EditFabricAsync(FabricEditBindingModel model)
        {
            Validator.EnsureNotNull(model, ValidationConstants.FabricDefinedMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Name, ValidationConstants.FabricNameMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Slug, ValidationConstants.FabricSlugMessage);
            Validator.EnsureStringNotNullOrEmpty(model.Description, ValidationConstants.FabricDescriptionMessage);
            Validator.EnsureStringNotNullOrEmpty(model.ImageUrl, ValidationConstants.FabricImageUrlMessage);

            var dbFabric= this.DbContext.Fabrics.Find(model.Id);

            dbFabric.Name = model.Name;
            dbFabric.Slug = model.Slug;
            dbFabric.Description = model.Description;
            dbFabric.ImageUrl = model.ImageUrl;

            await this.DbContext.SaveChangesAsync();

            return dbFabric;
        }
    }
}
