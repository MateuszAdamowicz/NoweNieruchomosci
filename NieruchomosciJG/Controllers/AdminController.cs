using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Context.Entities;
using Context.PartialModels;
using Models.ViewModels;
using Services.CRUD.AdvertServices.CreateAdvertService;
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

        public AdminController(
            IGetPropertiesByAdvertType getPropertiesByAdvertType,
            IPhotoService photoService,
            IGetAdvertTypes getAvailableAdvertTypes,
            ICreateAdvertService createAdvertService)
        {
            _getPropertiesByAdvertType = getPropertiesByAdvertType;
            _photoService = photoService;
            _getAvailableAdvertTypes = getAvailableAdvertTypes;
            _createAdvertService = createAdvertService;
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var advertTypes = _getAvailableAdvertTypes.GetAdvertTypeNameAndMask();
            return View(advertTypes);
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
            return View("_AdminMenu", model);
        }
    }
}