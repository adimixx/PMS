using AutoMapper;
using PMS.Models;
using PMS.Models.Database;
using System.Linq;
using System.Web.Mvc;

namespace PMS.Controllers
{

    public class StudioPermalinkController : Controller
    {
        photogEntities db = new photogEntities();

        [StudioPermalinkValidate]
        // GET: Studio Profile Page
        public ActionResult Index()
        {
            long studioID = (long)ViewBag.StudioID;
            var studio = db.Studios.FirstOrDefault(x => x.id == studioID);
            ViewBag.IsStudioIndex = "true";

            return View(studio);
        }

        [HttpGet]
        [StudioPermalinkValidate(RoleID = 1)]
        public ActionResult Settings()
        {
            long studioID = (long)ViewBag.StudioID;
            Studio studio = db.Studios.FirstOrDefault(x => x.id == studioID);

            //AutoMapper
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Studio, CreateStudioViewModel>();
            });
            IMapper mapper = config.CreateMapper();

            var create = mapper.Map<Studio, CreateStudioViewModel>(studio);
            ViewBag.IsStudioSetting = "true";
            return View(create);
        }

        [HttpPost]
        [StudioPermalinkValidate(RoleID = 1)]
        public ActionResult Settings(CreateStudioViewModel createStudio)
        {
            createStudio.name = createStudio.name?.Trim();
            ViewBag.IsStudioSetting = "true";

            if (string.IsNullOrWhiteSpace(createStudio.name))
            {
                ModelState.AddModelError("name", "Studio Name cannot be null");
            }

            else
            {
                if (db.Studios.FirstOrDefault(x=>x.name.ToLower() == createStudio.name.ToLower() && x.id != createStudio.id) != null)
                {
                    ModelState.AddModelError("name", "Studio Name is not available");
                }
            }

            if (!int.TryParse(createStudio.phoneNum, out int result))
            {
                ModelState.AddModelError("phoneNum", "Invalid Phone Number");
            }

            if (!Backbone.IsValidEmail(createStudio.email))
            {
                ModelState.AddModelError("email", "Invalid Email Address");
            }

            if (ModelState.IsValid)
            {
                var studio = db.Studios.FirstOrDefault(x => x.id == createStudio.id);
                studio.name = createStudio.name;
                studio.shortDesc = createStudio.shortDesc;
                studio.phoneNum = createStudio.phoneNum;
                studio.email = createStudio.email;
                studio.State = createStudio.SelectedState?.Trim();
                studio.City = createStudio.SelectedCity?.Trim();
                studio.longDesc = createStudio.longDesc;
                db.SaveChanges();

                TempData["Changes"] = "Studio profile have been updated successfully";
                return Redirect(string.Format("/{0}/{1}", ViewBag.StudioUrl , "Settings"));
            }

            return View(createStudio);
        }

        [HttpGet]
        [StudioPermalinkValidate(RoleID = 1)]
        public ActionResult ChangeStudioUsername()
        {
            long studioID = (long)ViewBag.StudioID;
            var studio = db.Studios.FirstOrDefault(x => x.id == studioID);
            ViewBag.IsStudioSetting = "true";
            return View(studio);
        }

        [HttpPost]
        [StudioPermalinkValidate(RoleID = 1)]
        public ActionResult ChangeStudioUsername(Studio studio)
        {
            ViewBag.IsStudioSetting = "true";

            photogEntities db = new photogEntities();
            var username = studio.uniquename?.Trim();

            studio = db.Studios.FirstOrDefault(x => x.id == studio.id);
            studio.uniquename = username;


            if (string.IsNullOrWhiteSpace(username))
            {
                ModelState.AddModelError("uniquename", "Studio Username cannot be null");                
            }

            else
            {
                var checkUsername = db.Studios.FirstOrDefault(x => x.uniquename.ToLower() == username.ToLower() && x.id != studio.id);

                if (checkUsername != null)
                {
                    ModelState.AddModelError("uniquename", "Studio Username is already taken by other studio");
                }
            }

            if (ModelState.IsValid)
            {
                db.SaveChanges();

                TempData["Changes"] = "Studio Username have been changed successfully";
                return Redirect(string.Format("/{0}/{1}", username, "Settings"));
            }

            return View(studio);            
        }

        // GET: StudioUser
        [StudioPermalinkValidate(RoleID = 1)]
        public ActionResult Roles()
        {
            return View("StudioRoles");
        }
    }
}