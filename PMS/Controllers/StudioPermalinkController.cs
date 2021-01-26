using AutoMapper;
using PMS.Models;
using PMS.Models.Database;
using System;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Helpers;
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
        public ActionResult viewstat()
        {

            long studioID = (long)ViewBag.StudioID;
            var studio = db.Studios.FirstOrDefault(x => x.id == studioID);
            return View(studio);
        }

        [HttpGet]
        [StudioPermalinkValidate(RoleID = 1)]
        public ActionResult seechart()
        {//array for storing x-value and y-value
            ArrayList xval = new ArrayList();
            ArrayList yval = new ArrayList();
            int studioID = (int)ViewBag.StudioID;

            //select result set from database
            var result = db.bestpackage(studioID).ToList();
            //put result set into two array
            if (result.Count != 0)
            {
                result.ToList().ForEach(x => xval.Add(x.package));
                result.ToList().ForEach(x => yval.Add(x.quantity));

                new Chart(width: 600, height: 400, theme: ChartTheme.Vanilla).AddSeries("Default", chartType: "Column", xValue: xval, yValues: yval).SetYAxis(title: "Money Earn(RM)")
          .SetXAxis(title: "Package").Write();

            }
            return null;
        }

        [HttpGet]
        [StudioPermalinkValidate(RoleID = 1)]
        public ActionResult seepiechart()
        {
            int studioID = (int)ViewBag.StudioID;
            ArrayList xval = new ArrayList();
            ArrayList yval = new ArrayList();
            var result = db.beststaff(studioID).Where(x => x.times != 0).Take(5).ToList();
            decimal? pu = 0;
            if (result.Count != 0)
            {
                foreach (var item in result)
                {
                    pu = pu + item.times;
                }
                result.ToList().ForEach(x => xval.Add(x.name + "(" + Math.Round((Double)(x.times / pu) * 100, 1) + "%)"));
                result.ToList().ForEach(x => yval.Add(x.times));
                var c = new Chart(width: 600, height: 400, theme: ChartTheme.Vanilla).AddSeries("Default", chartType: "Pie", xValue: xval, yValues: yval).SetYAxis(title: "Money Earned(RM)")
                .SetXAxis(title: "Months of " + DateTime.Now.ToString("yyyy")).Write();
            }

            return null;
        }

        [HttpGet]
        [StudioPermalinkValidate(RoleID = 1)]
        public ActionResult Settings()
        {
            long studioID = (long)ViewBag.StudioID;
            Studio studio = db.Studios.FirstOrDefault(x => x.id == studioID);

            //AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Studio, CreateStudioViewModel>();
            });
            IMapper mapper = config.CreateMapper();

            var create = mapper.Map<Studio, CreateStudioViewModel>(studio);
            ViewBag.IsStudioSetting = "1";
            ViewBag.Header = "Studio Settings";
            return View(create);
        }

        [HttpPost]
        [StudioPermalinkValidate(RoleID = 1)]
        public ActionResult Settings(CreateStudioViewModel createStudio)
        {
            createStudio.name = createStudio.name?.Trim();
            createStudio.SelectedCity = createStudio.SelectedCity?.Trim();
            createStudio.SelectedState = createStudio.SelectedState?.Trim();

            ViewBag.IsStudioSetting = "1";
            ViewBag.Header = "Studio Settings";

            if (db.Studios.FirstOrDefault(x => x.name.ToLower() == createStudio.name.ToLower() && x.id != createStudio.id) != null)
            {
                ModelState.AddModelError("name", "Studio Name is not available");
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
                var studio = db.Studios.FirstOrDefault(x => x.id == createStudio.id);

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

                studio.name = createStudio.name;
                studio.shortDesc = createStudio.shortDesc;
                studio.phoneNum = createStudio.phoneNum;
                studio.email = createStudio.email;
                studio.State = createStudio.SelectedState;
                studio.City = createStudio.SelectedCity;
                studio.longDesc = createStudio.longDesc;

                if (!string.IsNullOrWhiteSpace(createStudio.Facebook) && studio.StudioLinks.FirstOrDefault(x => x.name.ToLower() == "facebook") == null)
                {
                    studio.StudioLinks.Add(new StudioLink { name = "Facebook", address = createStudio.Facebook });
                }

                if (!string.IsNullOrWhiteSpace(createStudio.Twitter) && studio.StudioLinks.FirstOrDefault(x => x.name.ToLower() == "twitter") == null)
                {
                    studio.StudioLinks.Add(new StudioLink { name = "Twitter", address = createStudio.Twitter });
                }

                if (!string.IsNullOrWhiteSpace(createStudio.Instagram) && studio.StudioLinks.FirstOrDefault(x => x.name.ToLower() == "instagram") == null)
                {
                    studio.StudioLinks.Add(new StudioLink { name = "Instagram", address = createStudio.Instagram });
                }

                for (int i = 0; i < studio.StudioLinks.Count(); i++)
                {
                    if (studio.StudioLinks.ElementAt(i).name.ToLower() == "facebook")
                    {
                        if (string.IsNullOrWhiteSpace(createStudio.Facebook))
                        {
                            studio.StudioLinks.Remove(studio.StudioLinks.ElementAt(i));
                        }
                        else
                            studio.StudioLinks.ElementAt(i).address = createStudio.Facebook;
                    }
                    else if (studio.StudioLinks.ElementAt(i).name.ToLower() == "twitter")
                    {
                        if (string.IsNullOrWhiteSpace(createStudio.Twitter))
                        {
                            studio.StudioLinks.Remove(studio.StudioLinks.ElementAt(i));
                        }
                        else
                            studio.StudioLinks.ElementAt(i).address = createStudio.Twitter;
                    }
                    else if (studio.StudioLinks.ElementAt(i).name.ToLower() == "instagram")
                    {
                        if (string.IsNullOrWhiteSpace(createStudio.Instagram))
                        {
                            studio.StudioLinks.Remove(studio.StudioLinks.ElementAt(i));
                        }
                        else

                            studio.StudioLinks.ElementAt(i).address = createStudio.Instagram;
                    }
                }

                db.SaveChanges();

                TempData["Changes"] = "Studio profile have been updated successfully";
                return Redirect(string.Format("/{0}/{1}", ViewBag.StudioUrl, "Settings"));
            }

            return View(createStudio);
        }

        [HttpGet]
        [StudioPermalinkValidate(RoleID = 1)]
        public ActionResult ChangeStudioUsername()
        {
            long studioID = (long)ViewBag.StudioID;
            var studio = db.Studios.FirstOrDefault(x => x.id == studioID);
            ViewBag.IsStudioSetting = "2";
            return View(studio);
        }

        [HttpPost]
        [StudioPermalinkValidate(RoleID = 1)]
        public ActionResult ChangeStudioUsername(Studio studio)
        {
            var regexItem = new Regex("^[a-zA-Z0-9]*$");
            ViewBag.IsStudioSetting = "2";

            photogEntities db = new photogEntities();
            var username = studio.uniquename?.Trim();

            studio = db.Studios.FirstOrDefault(x => x.id == studio.id);
            studio.uniquename = username;
            var notAllowed = new string[] { "api", "systemapi", "database", "chat", "account","studio","payment","package","job","jobc","jobstatus","home","index"};

            if (string.IsNullOrWhiteSpace(username))
            {
                ModelState.AddModelError("uniquename", "Studio Username cannot be null");
            }
            else if (notAllowed.FirstOrDefault(x=>x.ToLower() == username.ToLower()) != null)
            {
                ModelState.AddModelError("uniquename", "Entered username is not allowed");
            }

            else if (!regexItem.IsMatch(username))
            {
                ModelState.AddModelError("uniquename", "Studio Username cannot contain characters and spaces");
            }

            else if (username.Length > 20)
            {
                ModelState.AddModelError("uniquename", "Studio Username cannot be more than 20 words");
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