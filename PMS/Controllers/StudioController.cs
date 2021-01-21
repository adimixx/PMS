using PMS.Models;
using PMS.Models.Database;
using System.Linq;
using System.Web.Mvc;

namespace PMS.Controllers
{
    [Authorize]
    public class StudioController : Controller
    {
        photogEntities db = new photogEntities();

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
            ViewBag.IsStudioSetting = "true";
            ViewBag.Header = "Create New Studio";
            ViewBag.IsStudioSetting = "1";

            return View("~/Views/StudioPermalink/Settings.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CreateStudioViewModel createStudio)
        {
            createStudio.name = createStudio.name?.Trim();
            createStudio.SelectedCity = createStudio.SelectedCity?.Trim();
            createStudio.SelectedState = createStudio.SelectedState?.Trim();

            ViewBag.IsStudioSetting = "true";
            ViewBag.Header = "Create New Studio";
            ViewBag.IsStudioSetting = "1";

            if (string.IsNullOrWhiteSpace(createStudio.name))
            {
                ModelState.AddModelError("name", "Studio Name cannot be null");
            }

            else
            {
                if (db.Studios.FirstOrDefault(x => x.name.ToLower() == createStudio.name.ToLower()) != null)
                {
                    ModelState.AddModelError("name", "Studio Name is not available");
                }
            }

            if (!string.IsNullOrWhiteSpace(createStudio.phoneNum) && !int.TryParse(createStudio.phoneNum, out int result))
            {
                ModelState.AddModelError("phoneNum", "Invalid Phone Number");
            }

            if (!string.IsNullOrWhiteSpace(createStudio.email) && !Backbone.IsValidEmail(createStudio.email))
            {
                ModelState.AddModelError("email", "Invalid Email Address");
            }

            if (ModelState.IsValid)
            {
                var studio = new Studio();
                studio.name = createStudio.name;
                studio.shortDesc = createStudio.shortDesc;
                studio.phoneNum = createStudio.phoneNum;
                studio.email = createStudio.email;
                studio.State = createStudio.SelectedState;
                studio.City = createStudio.SelectedCity;
                studio.longDesc = createStudio.longDesc;
                studio.uniquename = Backbone.Random(5);
                

                if (!string.IsNullOrWhiteSpace(createStudio.Facebook))
                {
                    studio.StudioLinks.Add(new StudioLink { name = "Facebook", address = createStudio.Facebook });
                }

                if (!string.IsNullOrWhiteSpace(createStudio.Twitter))
                {
                    studio.StudioLinks.Add(new StudioLink { name = "Twitter", address = createStudio.Twitter });
                }

                if (!string.IsNullOrWhiteSpace(createStudio.Instagram))
                {
                    studio.StudioLinks.Add(new StudioLink { name = "Instagram", address = createStudio.Instagram });
                }

                UserStudio userCred = new UserStudio { userid = UserAuthentication.Identity().id, studioroleid = 1 };
                studio.UserStudios.Add(userCred);

                db.Studios.Add(studio);
                db.SaveChanges();

                AzureBlob blob = new AzureBlob(4);
                try
                {
                    blob.MoveBlobFromTemp(2, studio.id.ToString(), createStudio.ImgLogo);
                    studio.ImgLogo = createStudio.ImgLogo;
                }
                catch { }

                try
                {
                    blob.MoveBlobFromTemp(2, studio.id.ToString(), createStudio.ImgCover);
                    studio.ImgCover = createStudio.ImgCover;
                }
                catch { }

                db.SaveChanges();
                return Redirect(string.Format("/{0}", studio.uniquename));
            }

            return View("~/Views/StudioPermalink/Settings.cshtml", createStudio);           
        }
    }
}