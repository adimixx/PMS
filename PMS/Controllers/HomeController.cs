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

                else if (User.IsInRole("User"))
                {
                    return View("IndexUser");
                }
            }

            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Power()
        {
            if (User.IsInRole("Admin")) ;
            return View();
        }
    }
}
