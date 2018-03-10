using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class AreaController : Controller
    {
        // GET: Area
        public ActionResult Index()
        {
            return View();
        }
    }
}