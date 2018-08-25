namespace MagicOfSewing.Services.Admin.Interfaces
{
    using MagicOfSewing.Common.Admin.BindingModels;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminFabricsService
    {
        Task<IEnumerable<FabricConciseViewModel>> GetAllFabricsAsync();

        Task<FabricDetailsViewModel> GetFabricDetailsAsync(int id, string slug);

        Task<Fabric> AddFabricAsync(FabricCreationBindingModel model);

        Task<FabricEditBindingModel> GetFabricEditAsync(int id);

        Task<Fabric> EditFabricAsync(FabricEditBindingModel model);

        Task DeleteFabric(int id);
    }
}
