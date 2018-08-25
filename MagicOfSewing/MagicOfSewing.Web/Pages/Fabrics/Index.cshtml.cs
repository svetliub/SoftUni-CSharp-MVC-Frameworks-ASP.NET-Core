namespace MagicOfSewing.Web.Pages.Fabrics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Data;
    using MagicOfSewing.Web.Common;
    using static MagicOfSewing.Common.Constants.WebConstants;

    public class IndexModel : BasePage
    {
        private readonly IMapper mapper;

        public IndexModel(MagicOfSewingDbContext dbContext, IMapper mapper) : 
            base(dbContext)
        {
            this.mapper = mapper;
            this.Fabrics = new List<FabricConciseViewModel>();
            this.Models = new PaginatedList<FabricConciseViewModel>(new List<FabricConciseViewModel>(), 1, 1);
        }
                
        public IEnumerable<FabricConciseViewModel> Fabrics { get; set; }

        public PaginatedList<FabricConciseViewModel> Models { get; set; }

        public void OnGet(int pageIndex = 1)
        {
            pageIndex = Math.Max(1, pageIndex);

            var fabrics = this.DbContext.Fabrics
                .OrderBy(f => f.Name)
                .ToList();
            
            var totalPages = Math.Max(1, (int)Math.Ceiling(fabrics.Count() / (double)UsersFabricsCountOnPage));
            pageIndex = Math.Min(pageIndex, totalPages);

            this.Fabrics = this.mapper.Map<IEnumerable<FabricConciseViewModel>>(fabrics);

            var fabricsToShow = this.Fabrics
                .Skip((pageIndex - 1) * UsersFabricsCountOnPage)
                .Take(UsersFabricsCountOnPage)
                .ToList();

            this.Models = new PaginatedList<FabricConciseViewModel>(fabricsToShow, pageIndex, totalPages);            
        }
    }
}