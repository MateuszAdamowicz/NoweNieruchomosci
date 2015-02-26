using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.ViewModels;
using Services.AdminIndexService.AdminFilterAdvertService;
using Services.AdminIndexService.AdminFilterOptionsService;
using Services.AdminMenuServices;
using PagedList;

namespace NieruchomosciJG.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminMenuService _adminMenuService;
        private readonly IAdminFilterOptionsService _adminFilterOptionsService;
        private readonly IAdminFilterAdvertService _adminFilterAdvertService;

        public AdminController(IAdminMenuService adminMenuService, IAdminFilterOptionsService adminFilterOptionsService, IAdminFilterAdvertService adminFilterAdvertService)
        {
            _adminFilterOptionsService = adminFilterOptionsService;
            _adminMenuService = adminMenuService;
            _adminFilterAdvertService = adminFilterAdvertService;
        }


        public ActionResult Index(int? page, string number, bool? toLet, AdTypeAdmin? adType, string flatCity, string houseCity, string landCity, string allCity, int? priceFrom, int? priceTo, int? areaFrom, int? areaTo, DateTime? dateFrom, DateTime? dateTo, bool? filter, AdminSortOption? sortOption, bool? showHidden, bool sortDescAsc = false, int? perPage = 20)
        {
            var adminIndexFiltred = new AdminIndexFiltred()
            {
                Filter = filter,
                Page = (page ?? 1),
                AdTypeAdmin = adType,
                FlatCity = flatCity,
                HouseCity = houseCity,
                LandCity = landCity,
                AllCity = allCity,
                PriceFrom = priceFrom,
                PriceTo = priceTo,
                AreaFrom = areaFrom,
                AreaTo = areaTo,
                DateFrom = dateFrom,
                DateTo = dateTo,
                ShowHidden = showHidden,
                ToLet = toLet,
                Number = number,
                PerPage = perPage,
                SortDescAsc = sortDescAsc,
                SortOption = sortOption
            };

            var model = new AdminIndexViewModel();

            int pageSize = (perPage ?? 20);
            int pageNumber = (page ?? 1);

            if (filter != null && filter == true)
            {

                var adverts = _adminFilterAdvertService.FilterAdverts(showHidden, dateFrom, dateTo, adType, number,
                    priceFrom, priceTo, areaFrom, areaTo, flatCity, houseCity, landCity, allCity, toLet, sortOption, sortDescAsc);
                model.Adverts = adverts.ToPagedList(pageNumber, pageSize);
            }
            else
            {
                var adverts = _adminFilterAdvertService.ActiveAdverts(sortOption, sortDescAsc);
                model.Adverts = adverts.ToPagedList(pageNumber, pageSize);
            }
            var options = _adminFilterOptionsService.GetOptions();
            model.AdminIndexFilterOptions = options;
            model.AdminIndexFiltred = adminIndexFiltred;
            return View(model);
        }

        public ActionResult TopMenu()
        {
            var counters = _adminMenuService.GetMenuCounters();
            
            return PartialView("_Menu", counters);
        }
    }
}