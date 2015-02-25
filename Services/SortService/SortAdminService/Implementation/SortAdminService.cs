using System;
using System.Collections.Generic;
using System.Linq;
using Models.ViewModels;
using Services.EnumNameService.Implementation;

namespace Services.SortService.SortAdminService.Implementation
{
    public class SortAdminService : ISortAdminService
    {
        private readonly IEnumNameService _enumNameService;

        public SortAdminService(IEnumNameService enumNameService)
        {
            _enumNameService = enumNameService;
        }
        public IEnumerable<AdminAdvertToShow> SortAdverts(IEnumerable<AdminAdvertToShow> advertsToShow, AdminSortOption? adminSortOption, bool sortDescAsc)
        {
            if (adminSortOption != null)
            {
                switch (adminSortOption)
                {
                    case AdminSortOption.CreatedAt:
                        advertsToShow = advertsToShow.OrderBy(x => x.CreatedAt);
                        break;
                    case AdminSortOption.City:
                        advertsToShow = advertsToShow.OrderBy(x => x.City);
                        break;
                    case AdminSortOption.Price:
                        advertsToShow = advertsToShow.OrderBy(x => x.Price);
                        break;
                    case AdminSortOption.AdType:
                        advertsToShow = advertsToShow.OrderBy(x => _enumNameService.GetName(x.AdType));
                        break;
                    case AdminSortOption.Number:
                        advertsToShow = advertsToShow.OrderBy(x => Convert.ToInt32(x.Id));
                        break;
                    case AdminSortOption.ToLet:
                        advertsToShow = advertsToShow.OrderBy(x => x.ToLet);
                        break;
                    case AdminSortOption.Area:
                        advertsToShow = advertsToShow.OrderBy(x => x.Area);
                        break;
                    case AdminSortOption.Visible:
                        advertsToShow = advertsToShow.OrderBy(x => x.Visible);
                        break;
                    default:
                        advertsToShow = advertsToShow.OrderBy(x => x.CreatedAt);
                        break;
                }
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