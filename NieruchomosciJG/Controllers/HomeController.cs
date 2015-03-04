using System.Collections.Generic;
using System.Web.Mvc;
using Context.Entities;
using Context.PartialModels;
using Models.ViewModels;
using Services.CitiesService;
using Services.CRUDAdvertServices.ReadAdvertService;
using Services.GenericRepository;
using Services.NewestAdvertsService;
namespace NieruchomosciJG.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewestAdvertsService _newestAdvertsService;
        private readonly ICitiesService _citiesService;
        private readonly IReadAdvertService _readAdvertService;


        // GET: Home
        public HomeController(INewestAdvertsService newestAdvertsService,
            ICitiesService citiesService,
            IReadAdvertService readAdvertService)
        {
            _newestAdvertsService = newestAdvertsService;
            _citiesService = citiesService;
            _readAdvertService = readAdvertService;
        }

        public ActionResult Show(int id)
        {
            var model = _readAdvertService.GetAdvertById(id);

            return View(model);
        }

        public ActionResult Index()
        {
            return View();
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