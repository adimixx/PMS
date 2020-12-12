using PMS.Models;
using PMS.Models.Database;
using System.Linq;
using System.Web.Mvc;

namespace PMS.Controllers
{
    [Authorize]
    public class StudioController : Controller
    {
        [HttpGet]
        public ActionResult Manage()
        {
            photogEntities db = new photogEntities();
            var studioList = db.Studios.ToList().Where(x => x.UserStudios.Any(y => y.userid == UserAuthentication.Identity().id)).ToList();

            return View("ManageStudios", studioList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateStudioViewModel model = new CreateStudioViewModel();
            return View("CreateNewStudio", model);
        }

        [HttpPost]
        public ActionResult Create(CreateStudioViewModel create)
        {
            if (ModelState.IsValid)
            {
                photogEntities db = new photogEntities();

                Studio studio = new Studio { name = create.Name, location = (string.IsNullOrWhiteSpace(create.SelectedState)) ? create.SelectedCity : string.Format("{0}, {1}", create.SelectedCity, create.SelectedState), uniquename = Backbone.Random(5) };
                db.Studios.Add(studio);
                db.SaveChanges();

                return Redirect(string.Format("/{0}",studio.uniquename));
            }

            return View("CreateNewStudio", create);
        }
    }
}