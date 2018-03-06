using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class ResultController : Controller
    {
        // GET: Result
        public ActionResult Index()
        {
            return Content("not implemented");
        }

        public ActionResult Empty()
        {
            // 空ページ返却
            return new EmptyResult();
        }
    }
}