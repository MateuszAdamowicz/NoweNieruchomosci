using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Context.Entities;
using Context.PartialModels;
using Models.ViewModels;
using Services.CountMessagesAndAdverts;
using Services.CRUD.AdvertServices.CreateAdvertService;
using Services.FilterAdvertService;
using Services.FilterOptionService;
using Services.GetAdvertTypes;
using Services.GetPropertiesByAdvertType;
using Services.PhotoService;
using PagedList;

namespace NieruchomosciJG.Controllers
{
    public class AdminController : Controller
    {
        private readonly IGetPropertiesByAdvertType _getPropertiesByAdvertType;
        private readonly IPhotoService _photoService;
        private readonly IGetAdvertTypes _getAvailableAdvertTypes;
        private readonly ICreateAdvertService _createAdvertService;
        private readonly ICountMessagesAndAdverts _countMessagesAndAdverts;
        private readonly IFilterOptionService _filterOptionService;
        private readonly IFilterAdvertService _filterAdvertService;

        public AdminController(
            IGetPropertiesByAdvertType getPropertiesByAdvertType,
            IPhotoService photoService,
            IGetAdvertTypes getAvailableAdvertTypes,
            ICreateAdvertService createAdvertService,
            ICountMessagesAndAdverts countMessagesAndAdverts,
            IFilterOptionService filterOptionService,
            IFilterAdvertService filterAdvertService)
        {
            _getPropertiesByAdvertType = getPropertiesByAdvertType;
            _photoService = photoService;
            _getAvailableAdvertTypes = getAvailableAdvertTypes;
            _createAdvertService = createAdvertService;
            _countMessagesAndAdverts = countMessagesAndAdverts;
            _filterOptionService = filterOptionService;
            _filterAdvertService = filterAdvertService;
        }


        [HttpGet]
        public ActionResult Index(int? page, string number, bool? toLet, string city, string adType, int? priceFrom, int? priceTo, int? areaFrom, int? areaTo, DateTime? dateFrom, DateTime? dateTo, bool? filter, AdminSortOption? sortOption, bool? showHidden, bool sortDescAsc = false, int? perPage = 20)
        {
            var adminIndexFiltered = new AdminIndexFiltered()
            {
                Filter = filter,
                Page = (page ?? 1),
                AdType = adType,
                City = city,
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

            if (filter == true && filter != null)
            {
                var adverts = _filterAdvertService.FilterAdverts(showHidden, dateFrom, dateTo, adType, number,
                       priceFrom, priceTo, areaFrom, areaTo, city, toLet, sortOption, sortDescAsc);
                model.Adverts = adverts.ToPagedList(pageNumber, pageSize);    
            }
            else
            {
                var adverts = _filterAdvertService.ActiveAdverts(sortOption, sortDescAsc);
                model.Adverts = adverts.ToPagedList(pageNumber, pageSize);
            }
            var options = _filterOptionService.GetOptions();
            model.AdminIndexFilterOptions = options;

            model.AdminIndexFiltered = adminIndexFiltered;

            return View(model);
        }

        [HttpGet]
        public ActionResult CreateAdvert(int mask)
        {

            var advertType = _getAvailableAdvertTypes.FindAdvertTypeByMask(mask);
            var properties = _getPropertiesByAdvertType.GetProperties(advertType);
            var model = new CreateAdvertViewModel() { Properties = properties, AdvertType = advertType };

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateAdvert(CreateAdvertViewModel model, List<PropertyViewModel> property)
        {
            model.Properties = property;
            if (ModelState.IsValid)
            {
                var id = _createAdvertService.CreateAdvert(model);
                return RedirectToAction("Index");
            }

            model.SavedPhotos = _photoService.GetPhotosById(model.PhotosToSave);
            return View(model);
        }

        public ActionResult Menu()
        {
            var model = new AdminMenuViewModel();
            model.AdvertTypes = _getAvailableAdvertTypes.GetAdvertTypeNameAndMask();
            model = _countMessagesAndAdverts.Count(model);

            return View("_AdminMenu", model);
        }
    }
}