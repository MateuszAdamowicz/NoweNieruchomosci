using System.Collections.Generic;
using Models.ViewModels;

namespace Services.SortService.SortAdminService
{
    public interface ISortAdminService
    {
        IEnumerable<AdminAdvertToShow> SortAdverts(IEnumerable<AdminAdvertToShow> advertsToShow, AdminSortOption? adminSortOption, bool sortDescAsc);
    }
}