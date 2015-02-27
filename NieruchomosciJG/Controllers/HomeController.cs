using System.Web.Mvc;
using Context.Entities;
using Services.GenericRepository;

namespace NieruchomosciJG.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}