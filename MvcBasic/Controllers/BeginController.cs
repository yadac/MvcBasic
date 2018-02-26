﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBasic.Models;

namespace MvcBasic.Controllers
{
    public class BeginController : Controller
    {
        public BeginController()
        {
            // loggin valid in controller
            _db.Database.Log = sql => Debug.Write(sql);
        }

        // GET: Begin
        public ActionResult Index()
        {
            return Content("Hello World!!");
        }

        public ActionResult Show()
        {
            // view var1 as ViewBag
            // this view var realize by dynamic, so intellisense has not worked.
            ViewBag.Message = "hello world!";

            // view var2 as ViewData
            ViewData["Message2"] = "good morning!";

            // helper method
            // call /views/{controller}/{action}.html
            // call /views/begin/show.html
            // if you set other view name at {action}, call other view, actions can share a view.
            return View();
        }

        public ActionResult List()
        {
            return View(_db.Members);
        }

        private readonly MvcBasicContext _db = new MvcBasicContext();
    }
}