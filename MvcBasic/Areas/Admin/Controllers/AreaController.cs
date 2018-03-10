using System.Web.Mvc;

namespace MvcBasic.Areas.Admin.Controllers
{
    public class AreaController : Controller
    {
        // GET: Admin/Area
        public ActionResult Index()
        {
            return View();
        }
    }
}