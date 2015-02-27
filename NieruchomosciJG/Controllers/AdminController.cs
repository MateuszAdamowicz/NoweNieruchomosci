using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Context.PartialModels;
using Models.ViewModels;
using Services.GetAvailableAdvertTypes;
using Services.GetPropertiesByAdvertType;
using Services.PhotoService;

namespace NieruchomosciJG.Controllers
{
    public class AdminController : Controller
    {
        private readonly IGetPropertiesByAdvertType _getPropertiesByAdvertType;
        private readonly IPhotoService _photoService;
        private readonly IGetAvailableAdvertTypes _getAvailableAdvertTypes;

        public AdminController(
            IGetPropertiesByAdvertType getPropertiesByAdvertType,
            IPhotoService photoService,
            IGetAvailableAdvertTypes getAvailableAdvertTypes)
        {
            _getPropertiesByAdvertType = getPropertiesByAdvertType;
            _photoService = photoService;
            _getAvailableAdvertTypes = getAvailableAdvertTypes;
        }

        [HttpGet]
        public ActionResult Create()
        {
            var advertTypes = _getAvailableAdvertTypes.GetAdvertTypes();
            return View(advertTypes);
        }

        [HttpGet]
        public ActionResult Create(AdvertType advertType)
        {
            var properties = _getPropertiesByAdvertType.GetProperties(advertType);
            var model = new CreateAdvertViewModel() {Properties = properties, AdvertType = advertType};

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateAdvertViewModel model, List<PropertyViewModel> property)
        {
            model.Properties = property;
            if (ModelState.IsValid)
            {

            }
            
            model.SavedPhotos = _photoService.GetPhotosById(model.PhotosToSave);
            return View(model);
        }
    }
}