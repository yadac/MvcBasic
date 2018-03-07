using System;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60)]
        public ActionResult CurrentTime()
        {
            // フラグメントキャッシュ
            return PartialView("_CurrentTimePartial", DateTime.Now);
        }
    }
}