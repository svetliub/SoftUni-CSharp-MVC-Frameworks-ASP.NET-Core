namespace MagicOfSewing.Web.Areas.Admin.Controllers
{
    using System.Threading.Tasks;
    using MagicOfSewing.Common.Admin.BindingModels;
    using MagicOfSewing.Services.Admin.Interfaces;
    using MagicOfSewing.Web.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static MagicOfSewing.Common.Constants.WebConstants;

    public class StrategiesController : AdminController
    {
        private const string StrategyConst = "strategy";

        private readonly IAdminStrategiesService strategiesService;

        public StrategiesController(IAdminStrategiesService strategiesService)
        {
            this.strategiesService = strategiesService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var strategies = await this.strategiesService.GetAllStrategiesAsync();

            return View(strategies);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Add(StrategyCreationBindingModel model)
        {
            var strategy = await this.strategiesService.AddStrategyAsync(model);

            SetSuccesfullMessage(AddedSuccessfully, StrategyConst);

            return this.RedirectToAction("Details", new { id = strategy.Id, slug = strategy.Slug });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, string slug)
        {
            var model = await this.strategiesService.GetStrategyDetailsAsync(id, slug);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, string slug)
        {
            var strategy = await this.strategiesService.GetStrategyEditAsync(id, slug);

            return View(strategy);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StrategyEditBindingModel model)
        {
            var strategy = await this.strategiesService.EditStrategyAsync(model);

            SetSuccesfullMessage(EditedSuccessfully, StrategyConst);

            return this.RedirectToAction("Details", new { id = strategy.Id, slug = strategy.Slug });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, string slug)
        {
            await this.strategiesService.DeleteStrategy(id, slug);

            SetSuccesfullMessage(DeletedSuccessfully, StrategyConst);

            return this.RedirectToAction("Index");
        }

        //private static Dictionary<int, int> SetPriority()
        //{
        //    return new Dictionary<int, int>
        //        {
        //            { 1, 1 },
        //            { 2, 2 },
        //            { 3, 3 },
        //            { 4, 4 },
        //            { 5, 5 },
        //            { 6, 6 }
        //        };
        //}
    }
}