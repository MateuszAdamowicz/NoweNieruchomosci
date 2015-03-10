using System.Collections.Generic;
using Models.ViewModels;

namespace Services.FilterAdvertService
{
    public interface IFilterAdvertService
    {
        IEnumerable<AdminAdvertToShow> ActiveAdverts(AdminSortOption? adminSortOption, bool sortDescAsc);
    }
}