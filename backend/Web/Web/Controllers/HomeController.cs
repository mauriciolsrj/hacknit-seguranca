using System.Web.Mvc;

namespace GuardaDigital.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Map()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contato";

            return View();
        }
    }
}