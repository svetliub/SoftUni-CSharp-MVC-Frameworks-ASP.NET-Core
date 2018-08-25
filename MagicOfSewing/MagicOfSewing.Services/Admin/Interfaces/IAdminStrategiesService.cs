namespace MagicOfSewing.Services.Admin.Interfaces
{
    using MagicOfSewing.Common.Admin.BindingModels;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminStrategiesService
    {
        Task<IEnumerable<StrategyConciseViewModel>> GetAllStrategiesAsync();

        Task<StrategyDetailsViewModel> GetStrategyDetailsAsync(int id, string slug);

        Task<Strategy> AddStrategyAsync(StrategyCreationBindingModel model);

        Task<StrategyEditBindingModel> GetStrategyEditAsync(int id, string slug);

        Task<Strategy> EditStrategyAsync(StrategyEditBindingModel model);

        Task DeleteStrategy(int id, string slug);
    }
}
