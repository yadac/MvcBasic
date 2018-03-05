using MvcBasic.Models;
using System.Linq;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class LinqController : Controller
    {
        // create context
        private MvcBasicContext _db = new MvcBasicContext();

        // GET: Linq
        public ActionResult Search(string keyword, bool? released)
        {
            // all data
            var articles = from a in _db.Articles select a;

            // if keyword exists
            if (!string.IsNullOrEmpty(keyword))
            {
                articles = articles.Where(a => a.Title.Contains(keyword));
            }

            if (released.HasValue && released.Value)
            {
                articles = articles.Where(a => a.Released);
            }

            return View(articles);
        }
    }
}