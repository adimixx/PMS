using PMS.Models;
using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        photogEntities db = new photogEntities();

        // ---------------------- Job Status Start ------------------------ //
        [HttpGet]
        public ActionResult JobStatusMain()
        {
            if (!UserAuthentication.Identity().UserSystemRoles.Any(x => x.systemroleid == 1))
                return View("error");

            return View();
        }

        [HttpGet]
        public ActionResult CreateJobStatus()
        {
            if (!UserAuthentication.Identity().UserSystemRoles.Any(x => x.systemroleid == 1))
                return View("error");

            return View(new JobStatu());
        }

        [HttpPost]
        public ActionResult createjobstatus(JobStatu data)
        {
            if (!UserAuthentication.Identity().UserSystemRoles.Any(x => x.systemroleid == 1))
                return View("error");

            if (ModelState.IsValid)
            {
                try
                {
                    db.JobStatus.Add(data);
                    db.SaveChanges();

                    return Redirect("/JobStatus");
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return View(data);
        }

        [HttpGet]
        public ActionResult editjobstatus(int id)
        {
            if (!UserAuthentication.Identity().UserSystemRoles.Any(x => x.systemroleid == 1))
                return View("error");

            var data = db.JobStatus.Find(id);

            return View(data);
        }

        [HttpPost]
        public ActionResult editjobstatus(JobStatu data)
        {
            if (!UserAuthentication.Identity().UserSystemRoles.Any(x => x.systemroleid == 1))
                return View("error");

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return Redirect("/jobstatus");
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return View(data);
        }

        [HttpGet]
        public ActionResult deletejobstatus(int id)
        {
            if (!UserAuthentication.Identity().UserSystemRoles.Any(x => x.systemroleid == 1))
                return View("error");

            try
            {
                var data = db.JobStatus.Find(id);
                db.JobStatus.Remove(data);
                db.SaveChanges();

                return Redirect("/jobstatus");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ---------------------- Job Status End ------------------------ //

        // ---------------------- Job Management Start ----------------------- //

        [StudioPermalinkValidate(RoleID = 2)]
        [HttpGet]
        public ActionResult JobHome()
        {
            return View();
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpGet]
        public ActionResult Detail(int id)
        {
            var data = db.Jobs.Find(id);

            if (ViewBag.StudioID != data.Package.studioid)
                return RedirectToAction("jobhome");

            return View(data);
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpGet]
        public ActionResult AssignStaff(int id)
        {
            return RedirectToAction("jobhome");
        }

        // ---------------------- Job Management End ----------------------- //
    }
}