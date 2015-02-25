using System;
using System.Collections.Generic;
using Models.ViewModels;

namespace Services.AdminIndexService.AdminFilterAdvertService
{
    public interface IAdminFilterAdvertService
    {
        IEnumerable<AdminAdvertToShow> FilterAdverts(bool? showHidden, DateTime? dateFrom, DateTime? dateTo, AdTypeAdmin? adType, string number, int? priceFrom, int? priceTo, int? areaFrom, int? areaTo, string flatCity, string houseCity, string landCity, string allCity, bool? toLet, AdminSortOption? adminSortOption, bool sortDescAsc);
        IEnumerable<AdminAdvertToShow> ActiveAdverts(AdminSortOption? adminSortOption, bool sortDescAsc);
    }
}