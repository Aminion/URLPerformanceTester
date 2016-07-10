using System.Web.Mvc;

namespace URLPerformanceTester.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}