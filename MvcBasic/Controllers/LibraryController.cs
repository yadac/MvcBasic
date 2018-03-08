using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class LibraryController : Controller
    {
        // GET: Library
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Jqueryui()
        {
            return View();
        }
    }
}