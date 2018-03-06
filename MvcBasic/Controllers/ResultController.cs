using MvcBasic.Models;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class ResultController : Controller
    {
        private MvcBasicContext _db = new MvcBasicContext();

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

        public ActionResult Tsv()
        {
            var members = _db.Members.ToList();
            var str = new StringBuilder();
            members.ForEach(m => str.Append($"{m.Id}\t{m.Name}\t{m.Email}\r\n"));
            return Content(str.ToString(), "text/tab-separated-values", Encoding.UTF8);

        }
    }
}