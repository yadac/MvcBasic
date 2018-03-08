using System.Web.Mvc;

namespace MvcBasic.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return Content("ここは Admin のホームです");

        }
    }
}