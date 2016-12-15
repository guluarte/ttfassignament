using System.Web.Mvc;

namespace TtfAssignment.WebService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Help");
        }
    }
}