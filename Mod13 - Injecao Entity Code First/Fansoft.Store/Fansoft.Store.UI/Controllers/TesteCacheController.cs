using System;
using System.Web.Mvc;

namespace Fansoft.Store.UI.Controllers
{
    public class TesteCacheController : Controller
    {

        [OutputCache(Duration = 10)]
        public ActionResult Index()
        {
            var model = new Random().Next(100);
            return View(model);
        }
    }
}
