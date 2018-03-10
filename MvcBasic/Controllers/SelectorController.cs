using MvcBasic.Extentions;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class SelectorController : Controller
    {

        // GET: Selector
        [Referrer(true)]
        public ActionResult Index()
        {
            return View();
        }
    }
}