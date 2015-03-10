using System;
using System.Collections.Generic;
using Models.ViewModels;

namespace Services.FilterAdvertService
{
    public interface IFilterAdvertService
    {
        IEnumerable<AdminAdvertToShow> ActiveAdverts(AdminSortOption? adminSortOption, bool sortDescAsc);

        IEnumerable<AdminAdvertToShow> FilterAdverts(bool? showHidden, DateTime? dateFrom, DateTime? dateTo, string adType,
            string number, int? priceFrom, int? priceTo, int? areaFrom, int? areaTo, string city, bool? toLet,
            AdminSortOption? adminSortOption, bool sortDescAsc);

    }
}