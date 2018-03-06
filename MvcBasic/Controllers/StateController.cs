using System;
using System.Web;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class StateController : Controller
    {
        // GET: State
        public ActionResult Index()
        {
            return Content("not implemented");
        }

        public ActionResult Cookie()
        {
            if (Request.Cookies["email"] != null)
            {
                ViewBag.Email = Request.Cookies["email"].Value;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Cookie(string email)
        {
            Response.AppendCookie(new HttpCookie("email")
            {
                Value = email,
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true,
            });

            return RedirectToAction("Cookie");
        }

        public ActionResult SessionRecord()
        {
            ViewBag.Email2 = Session["email2"];
            return View();
        }

        [HttpPost]
        public ActionResult SessionRecord(string email2)
        {
            Session["email2"] = email2;
            return RedirectToAction("SessionRecord");
        }

    }

}