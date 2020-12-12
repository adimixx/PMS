using PMS.Models;
using PMS.Models.Database;
using System.Linq;
using System.Web.Mvc;

namespace PMS.Controllers
{

    public class StudioPermalinkController : Controller
    {
        [StudioPermalinkValidate]
        // GET: Studio Profile Page
        public ActionResult Index()
        {
            ViewBag.Perm = HttpContext.Request.Url.PathAndQuery;

            return View();
        }


        [StudioPermalinkValidate]
        [StudioAuthorizationRole(RoleID = 1)]
        public ActionResult TestPage()
        {
            ViewBag.Perm = RouteData.Values.FirstOrDefault(x=>x.Key.ToLower() == "permalink").Value;

            return View();
        }
    }
}