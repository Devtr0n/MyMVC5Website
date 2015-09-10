using System.Web.Mvc;

namespace RichardHollonMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "An overview.";

            return View();
        }

        public ActionResult Resume()
        {
            //ViewBag.Message = "My resume.";

            return View();
        }

        public ActionResult Portfolio()
        {
            ViewBag.Message = "Portfolio - coming soon.";

            return View();
        }

        public ActionResult Blog()
        {
            ViewBag.Message = "Blog - coming soon.";

            return View();
        }

        public ActionResult Media()
        {
            ViewBag.Message = "Media & fun stuff.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact me:";

            return View();
        }
    }
}