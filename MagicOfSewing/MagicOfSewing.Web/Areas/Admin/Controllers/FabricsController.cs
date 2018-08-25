namespace MagicOfSewing.Web.Areas.Admin.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using MagicOfSewing.Common.Admin.BindingModels;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Services.Admin.Interfaces;
    using MagicOfSewing.Web.Common;
    using MagicOfSewing.Web.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static MagicOfSewing.Common.Constants.WebConstants;

    public class FabricsController : AdminController
    {
        private const string FabricConst = "fabric";

        private readonly IAdminFabricsService fabricsService;

        public FabricsController(IAdminFabricsService fabricsService)
        {
            this.fabricsService = fabricsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageIndex = 1)
        {
            pageIndex = Math.Max(1, pageIndex);

            var fabrics = await this.fabricsService.GetAllFabricsAsync();

            var totalPages = Math.Max(1, (int)Math.Ceiling(fabrics.Count() / (double)FabricsCountOnPage));
            pageIndex = Math.Min(pageIndex, totalPages);

            var fabricsToShow = fabrics
                .Skip((pageIndex - 1) * FabricsCountOnPage)
                .Take(FabricsCountOnPage)
                .ToList();

            var model = new PaginatedList<FabricConciseViewModel>(fabricsToShow, pageIndex, totalPages);

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Add(FabricCreationBindingModel model)
        {
            var fabric = await this.fabricsService.AddFabricAsync(model);

            SetSuccesfullMessage(AddedSuccessfully, FabricConst);

            return this.RedirectToAction("Details", new { id = fabric.Id, slug = fabric.Slug });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, string slug)
        {
            var model = await this.fabricsService.GetFabricDetailsAsync(id, slug);

            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var fabric = await this.fabricsService.GetFabricEditAsync(id);

            return View(fabric);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FabricEditBindingModel model)
        {
            var fabric = await this.fabricsService.EditFabricAsync(model);

            SetSuccesfullMessage(EditedSuccessfully, FabricConst);

            return this.RedirectToAction("Details", new { id = fabric.Id, slug = fabric.Slug });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.fabricsService.DeleteFabric(id);

            SetSuccesfullMessage(DeletedSuccessfully, FabricConst);

            return RedirectToAction("Index");
        }
    }
}