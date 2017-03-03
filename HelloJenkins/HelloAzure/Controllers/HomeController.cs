using System.Web.Configuration;
using System.Web.Mvc;

namespace HelloAzure.Controllers {
    public class HomeController : Controller {
        public ActionResult Index()
        {
            ViewBag.Title = WebConfigurationManager.AppSettings["apptitle"] ?? "No Title";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This demo shows CI build in action.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Walking Tree Technologies.";

            return View();
        }

    }
}