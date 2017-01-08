using System.Web.Mvc;

namespace Delta.AppHarbor.Controllers
{
    public class MyStockController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "My Stock";
            return View();
        }
    }
}
