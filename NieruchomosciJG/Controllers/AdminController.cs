using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Context.Entities;
using Context.PartialModels;
using Models.ViewModels;
using Services.CountMessagesAndAdverts;
using Services.CRUD.AdvertServices.CreateAdvertService;
using Services.FilterOptionService;
using Services.GetAdvertTypes;
using Services.GetPropertiesByAdvertType;
using Services.PhotoService;

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

        public AdminController(
            IGetPropertiesByAdvertType getPropertiesByAdvertType,
            IPhotoService photoService,
            IGetAdvertTypes getAvailableAdvertTypes,
            ICreateAdvertService createAdvertService,
            ICountMessagesAndAdverts countMessagesAndAdverts,
            IFilterOptionService filterOptionService)
        {
            _getPropertiesByAdvertType = getPropertiesByAdvertType;
            _photoService = photoService;
            _getAvailableAdvertTypes = getAvailableAdvertTypes;
            _createAdvertService = createAdvertService;
            _countMessagesAndAdverts = countMessagesAndAdverts;
            _filterOptionService = filterOptionService;
        }


        [HttpGet]
        public ActionResult Index()
        {
            var model = new AdminIndexViewModel();

            var options = _filterOptionService.GetOptions();
            model.AdminIndexFilterOptions = options;
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateAdvert(int mask)
        {

            var advertType = _getAvailableAdvertTypes.FindAdvertTypeByMask(mask);
            var properties = _getPropertiesByAdvertType.GetProperties(advertType);
            var model = new CreateAdvertViewModel() {Properties = properties, AdvertType = advertType};

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