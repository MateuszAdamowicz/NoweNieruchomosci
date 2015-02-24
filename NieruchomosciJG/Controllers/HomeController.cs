using System.Web.Mvc;
using Context.Entities;
using Services.GenericRepository;

namespace NieruchomosciJG.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericRepository _genericRepository;

        public HomeController(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;

            _genericRepository.GetSet<PropertyDictionary>();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}