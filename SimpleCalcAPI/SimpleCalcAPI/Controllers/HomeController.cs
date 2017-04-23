using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCalcAPI.Controllers {
    public class HomeController : Controller {
        public ActionResult Index()
        {
            ViewBag.Title = "World's best calc";

            return View();
        }
    }
}
