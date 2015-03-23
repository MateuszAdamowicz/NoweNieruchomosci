using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Context.Entities;
using Context.PartialModels;
using Models.ViewModels;
using Services.AdminLoginService;
using Services.CountMessagesAndAdverts;
using Services.CRUDAdvertServices.CreateAdvertService;
using Services.CRUDAdvertServices.DeleteAdvertService;
using Services.CRUDAdvertServices.ReadAdvertService;
using Services.CRUDAdvertServices.UpdateAdvertService;
using Services.CRUDAdvertServices.UpdateAdvertService.Implementation;
using Services.FilterAdvertService;
using Services.FilterOptionService;
using Services.GetAdvertTypes;
using Services.GetPropertiesByAdvertType;
using Services.MessageSerivce;
using Services.PhotoService;
using PagedList;

namespace NieruchomosciJG.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IGetPropertiesByAdvertType _getPropertiesByAdvertType;
        private readonly IPhotoService _photoService;
        private readonly IGetAdvertTypes _getAvailableAdvertTypes;
        private readonly ICreateAdvertService _createAdvertService;
        private readonly ICountMessagesAndAdverts _countMessagesAndAdverts;
        private readonly IFilterOptionService _filterOptionService;
        private readonly IFilterAdvertService _filterAdvertService;
        private readonly IReadAdvertService _readAdvertService;
        private readonly IUpdateAdvertService _updateAdvertService;
        private readonly IDeleteAdvertService _deleteAdvertService;
        private readonly IAdminLoginService _adminLoginService;
        private readonly IMessageService _messageService;

        public AdminController(
            IGetPropertiesByAdvertType getPropertiesByAdvertType,
            IPhotoService photoService,
            IGetAdvertTypes getAvailableAdvertTypes,
            ICreateAdvertService createAdvertService,
            ICountMessagesAndAdverts countMessagesAndAdverts,
            IFilterOptionService filterOptionService,
            IFilterAdvertService filterAdvertService,
            IReadAdvertService readAdvertService,
            IUpdateAdvertService updateAdvertService,
            IDeleteAdvertService deleteAdvertService,
            IAdminLoginService adminLoginService,
            IMessageService messageService)
        {
            _getPropertiesByAdvertType = getPropertiesByAdvertType;
            _photoService = photoService;
            _getAvailableAdvertTypes = getAvailableAdvertTypes;
            _createAdvertService = createAdvertService;
            _countMessagesAndAdverts = countMessagesAndAdverts;
            _filterOptionService = filterOptionService;
            _filterAdvertService = filterAdvertService;
            _readAdvertService = readAdvertService;
            _updateAdvertService = updateAdvertService;
            _deleteAdvertService = deleteAdvertService;
            _adminLoginService = adminLoginService;
            _messageService = messageService;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View(new LoginViewModel());
            }
            var ticket = new FormsAuthenticationTicket(1, "", DateTime.Now, DateTime.Now.AddMinutes(-30), false, String.Empty, FormsAuthentication.FormsCookiePath);
            _adminLoginService.Cookies().Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket)));
            _adminLoginService.Logout();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _adminLoginService.Login(loginViewModel);
                if (result.Authorized)
                {
                    string user = HttpContext.User.ToString();
                    _adminLoginService.SetLoginCookies(loginViewModel.Login);
                    return RedirectToAction("Index");
                }
                ViewBag.LoginError = true;
                return View(loginViewModel);
            }
            ViewBag.LoginError = true;
            return View(loginViewModel);
        }

        [HttpGet]
        public ActionResult Index(int? page, string number, bool? toLet, string city, int? adType, int? priceFrom, int? priceTo, int? areaFrom, int? areaTo, DateTime? dateFrom, DateTime? dateTo, bool? filter, AdminSortOption? sortOption, bool? showHidden, bool sortDescAsc = false, int? perPage = 20)
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

            if ((ChangeAdvert)TempData["Change"] != null)
            {
                TempData["Change"] = (ChangeAdvert)TempData["Change"];
            }

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

        [HttpGet]
        public ActionResult EditAdvert(int id)
        {
            var model = _readAdvertService.GetCreateAdvertById(id);

            model.SavedPhotos = _photoService.GetPhotosByAdvertId(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditAdvert(CreateAdvertViewModel model, List<PropertyViewModel> property, int id)
        {
            model.Properties = property;
            if (ModelState.IsValid)
            {
                var idd = _updateAdvertService.UpdateAdvert(model, id);
                return RedirectToAction("Index");
            }

            model.SavedPhotos = _photoService.GetPhotosByIdAndAdvertId(model.PhotosToSave,id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeAdvertVisibility(int advertId, int? page, string number, bool? toLet, string city, int? adType, int? priceFrom, int? priceTo, int? areaFrom, int? areaTo, DateTime? dateFrom, DateTime? dateTo, bool? filter, AdminSortOption? sortOption, bool? showHidden, bool sortDescAsc, int? perPage)
        {
            var changeAdvert = new ChangeAdvert();
            changeAdvert.Deleted = false;
            changeAdvert.Visible = _updateAdvertService.ChangeVisibility(advertId);
            changeAdvert.Number = advertId;

            TempData["Change"] = changeAdvert;

            return RedirectToAction("Index", new {page, number, toLet, city, adType, priceFrom, priceTo, areaFrom,  areaTo, dateFrom, dateTo, filter, sortOption, showHidden, sortDescAsc, perPage});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAdvert(int advertId, int? page, string number, bool? toLet, string city, int? adType, int? priceFrom, int? priceTo, int? areaFrom, int? areaTo, DateTime? dateFrom, DateTime? dateTo, bool? filter, AdminSortOption? sortOption, bool? showHidden, bool sortDescAsc, int? perPage)
        {
            _deleteAdvertService.DeleteAdvert(advertId);
            var changeAdvert = new ChangeAdvert();
            changeAdvert.Deleted = true;
            changeAdvert.Visible = false; 
            changeAdvert.Number = advertId;

            TempData["Change"] = changeAdvert;

            return RedirectToAction("Index", new { page, number, toLet, city, adType, priceFrom, priceTo, areaFrom, areaTo, dateFrom, dateTo, filter, sortOption, showHidden, sortDescAsc, perPage });

        }

        public ActionResult Menu()
        {
            var model = new AdminMenuViewModel();
            model.AdvertTypes = _getAvailableAdvertTypes.GetAdvertTypeNameAndMask();
            model = _countMessagesAndAdverts.Count(model);

            return View("_AdminMenu", model);
        }



        public ActionResult Messages(int? page, int? deleted)
        {
            IEnumerable<MessageViewModel> messages = _messageService.GetMessages();
            
            const int pageSize = 20;
            int pageNumber = (page ?? 1);

            var model = messages.ToPagedList(pageNumber, pageSize);

            var mvm = new MessagesViewModel() { Messages = model, Deleted = deleted };

            return View(mvm);
        }

        public ActionResult DeleteMessage(int id)
        {
            _messageService.DeleteMessage(id);
            TempData["Deleted"] = id;
            return RedirectToAction("Messages",new {deleted = id});
        }
    }
}