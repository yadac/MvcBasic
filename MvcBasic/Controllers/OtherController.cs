using MvcBasic.Models;
using System;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class OtherController : Controller
    {
        private MvcBasicContext db = new MvcBasicContext();


        // GET: Other
        public ActionResult Insert()
        {
            // get target article
            var article = db.Articles.Find(2);

            // add comment
            db.Comments.Add(new Comment()
            {
                Article = article,
                Name = "Koizumi",
                Body = "感動した！",
                Updated = DateTime.Parse("2014-6-20")
            });
            db.SaveChanges();

            return Content("Added Comment");
        }
    }
}