namespace MagicOfSewing.Services.Users.Interfaces
{
    using MagicOfSewing.Common.Admin.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IStrategiesService
    {
        Task<IEnumerable<StrategyConciseViewModel>> GetAllStrategiesAsync();
    }
}
