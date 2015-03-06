using System.Collections.Generic;
using System.Web.Mvc;
using Context.Entities;
using Context.PartialModels;
using Models.ViewModels;
using PagedList;
using Services.AdvertSearchOptionsService;
using Services.AdvertSearchOptionsService.Implementation;
using Services.CitiesService;
using Services.CRUDAdvertServices.ReadAdvertService;
using Services.FilterOptionService;
using Services.GenericRepository;
using Services.NewestAdvertsService;
using Services.SearchAdvertService;

namespace NieruchomosciJG.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewestAdvertsService _newestAdvertsService;
        private readonly ICitiesService _citiesService;
        private readonly IReadAdvertService _readAdvertService;
        private readonly IFilterOptionService _filterOptionService;
        private readonly IAdvertSearchOptionService _advertSearchOptionService;
        private readonly ISearchAdvertService _searchAdvertService;

        const int PageSize = 4;


        // GET: Home
        public HomeController(INewestAdvertsService newestAdvertsService,
            ICitiesService citiesService,
            IReadAdvertService readAdvertService, 
            IFilterOptionService filterOptionService,
            IAdvertSearchOptionService advertSearchOptionService,
            ISearchAdvertService searchAdvertService)
        {
            _newestAdvertsService = newestAdvertsService;
            _citiesService = citiesService;
            _readAdvertService = readAdvertService;
            _filterOptionService = filterOptionService;
            _advertSearchOptionService = advertSearchOptionService;
            _searchAdvertService = searchAdvertService;
        }



        [HttpPost]
        public ActionResult Show(AdvertContactEmailViewModel advertContactEmail, int id)
        {
            var model = _readAdvertService.GetAdvertById(id);
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            var model = _readAdvertService.GetAdvertById(id);

            return View(model);
        }

        public ActionResult Index(bool? search, int? page, int? priceFrom, int? priceTo, string city, bool? toLet, string adType, SortOption? sortOptions)
        {
            var model = new IndexViewModel
            {
                RouteValues =
                {
                    Search = search,
                    Page = (page ?? 1),
                    PriceFrom = priceFrom,
                    PriceTo = priceTo,
                    City = city,
                    ToLet = toLet,
                    AdType = adType,
                    SortOption = sortOptions
                }
            };

            model.SearchOptions = _advertSearchOptionService.GetOptions();

            if (search != null && search == true)
            {
                var adverts = _searchAdvertService.SearchAdverts(priceFrom, priceTo, city, toLet, adType, sortOptions);
                
                int pageNumber = (page ?? 1);
                model.SimplifyAdverts = adverts.ToPagedList(pageNumber, PageSize);
            }

            return View(model);
        }

        public ActionResult Cities()
        {
            var cities = _citiesService.CitiesWithMaximumNumberOfAdverts(4);
            return PartialView("_Cities", cities);
        }

        public ActionResult NewestAdverts()
        {
            var adverts = _newestAdvertsService.GetNewest(4);
            return PartialView("_NewestAdverts",adverts);
        }

        public ActionResult MinMap(string lng, string lat)
        {
            return PartialView("_MinMap", new MapCords() { Lat = lat, Lng = lng });
        }
    }
}