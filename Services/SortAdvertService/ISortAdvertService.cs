using System.Collections.Generic;
using Models.ViewModels;

namespace Services.SortAdvertService
{
    public interface ISortAdvertService
    {
        IEnumerable<AdminAdvertToShow> SortAdverts(IEnumerable<AdminAdvertToShow> advertsToShow, AdminSortOption? adminSortOption, bool sortDescAsc);
    }
}