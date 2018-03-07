using System;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    [Authorize]
    public class FilterController : Controller
    {
        [OutputCache(Duration = 600)]
        // GET: Filter
        public ActionResult Index()
        {
            return Content("not implemented");
        }

        [AllowAnonymous]
        public ActionResult Exception()
        {
            throw new Exception("Fatal Error");
        }
    }
}