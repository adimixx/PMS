using PMS.Models;
using PMS.Models.Database;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    return View("IndexAdmin");
                }
            }

            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        public ActionResult Search(SearchViewModel srcres)
        {
            //SearchViewModel src = new SearchViewModel { Search = srcres.Search };
            return View(srcres);
        }
    }
}
