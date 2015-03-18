using System;
using System.Collections.Generic;
using System.Linq;
using Models.ViewModels;
using Services.DetailedSortService;

namespace Services.SortAdvertService.Implementation
{
    public class SortAdvertService : ISortAdvertService
    {
        private readonly IDetailedSortService _detailedSortService;

        public SortAdvertService(IDetailedSortService detailedSortService)
        {
            _detailedSortService = detailedSortService;
        }

        public IEnumerable<AdminAdvertToShow> SortAdverts(IEnumerable<AdminAdvertToShow> advertsToShow, AdminSortOption? adminSortOption, bool sortDescAsc)
        {

            advertsToShow = advertsToShow.ToList();
            if (adminSortOption != null)
            {
                advertsToShow = _detailedSortService.Sort(adminSortOption.Value, advertsToShow);
                if (sortDescAsc)
                {
                    advertsToShow = advertsToShow.Reverse();
                }
            }
            else advertsToShow = advertsToShow.OrderByDescending(x => x.CreatedAt);

            return advertsToShow;
        }
    }
}