using System.Text;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class RouteController : Controller
    {
        // GET: Route
        public ActionResult Index()
        {
            return Content("not imple");
        }

        public ActionResult Test()
        {
            var builder = new StringBuilder();
            foreach (var r in RouteData.Values)
            {
                builder.Append($"{r.Key}:{r.Value}<br />");
            }

            return Content(builder.ToString());
        }
    }
}