namespace MagicOfSewing.Web.Areas.Users.Controllers
{
    using System.Threading.Tasks;
    using MagicOfSewing.Services.Users.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    public class StrategiesController : Controller
    {
        private readonly IStrategiesService strategiesService;

        public StrategiesController(IStrategiesService strategiesService)
        {
            this.strategiesService = strategiesService;
        }

        public async Task<IActionResult> Index()
        {
            var strategies = await this.strategiesService.GetAllStrategiesAsync();

            return View(strategies);
        }
    }
}