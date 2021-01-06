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

        [StudioPermalinkValidate]
        [HttpGet]
        public ActionResult Detail(int id)
        {
            var job = db.Jobs.Find(id);
            var jobdate = job != null ? db.JobDates.OrderByDescending(x => x.id).FirstOrDefault(x => x.jobid == id) : null;
            var jobdateuser = jobdate != null ? db.JobDateUsers.OrderByDescending(x => x.id).FirstOrDefault(x => x.jobdateid == jobdate.id) : null;
            var jobcharge = job != null ? db.JobCharges.FirstOrDefault(x => x.jobid == id) : null;

            if (ViewBag.StudioID != job.Package.studioid)
                return RedirectToAction("jobhome");

            return View(new Tuple<Job, JobDate, JobDateUser, JobCharge>(job, jobdate, jobdateuser, jobcharge));
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpPost]
        public ActionResult ChangeStatus(int id, int jsid, int pid)
        {
            try
            {
                var data = db.Jobs.Find(id);
                data.jobstatusid = jsid;
                data.packageid = pid;
                db.SaveChanges();

                return RedirectToAction("detail/" + id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpPost]
        public ActionResult ChangeDate([Bind(Prefix = "Item2")]JobDate job, int jsid, DateTime jobdate, TimeSpan jobtime)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    job.jobstatusid = jsid;
                    job.jobdate1 = jobdate.Add(jobtime);
                    if (job.id != 0)
                    {
                        db.Entry(job).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        db.JobDates.Add(job);
                        db.SaveChanges();
                    }

                    return RedirectToAction("detail/" + job.jobid);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
                return View("Error");
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpGet]
        public ActionResult AssignStaff(int id, int? jduid, int jdid)
        {
            try
            {
                var jdu = new JobDateUser();
                if (jduid.HasValue)
                    jdu = db.JobDateUsers.Find(jduid.Value);

                var sid = (int)ViewBag.StudioID;
                ViewBag.UserStudioID = db.UserStudios.FirstOrDefault(x => x.studioid == sid && x.userid == id).id;
                ViewBag.JobDateID = jdid;

                return View(jdu);
            }
            catch (Exception)
            {
                return View("error");
            }
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpPost]
        public ActionResult AssignStaff(JobDateUser jobDateUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (jobDateUser.id == 0)
                    {
                        db.JobDateUsers.Add(jobDateUser);
                    }
                    else
                    {
                        db.Entry(jobDateUser).State = System.Data.Entity.EntityState.Modified;
                    }
                    db.SaveChanges();

                    return RedirectToAction("detail/" + db.JobDates.FirstOrDefault(x => x.id == jobDateUser.jobdateid).jobid);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return View("Error");
            }
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpPost]
        public ActionResult JobCharge([Bind(Prefix = "Item4")] JobCharge jobCharge, int cid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    jobCharge.chargeid = cid;
                    if (jobCharge.id == 0)
                    {
                        db.JobCharges.Add(jobCharge);
                    }
                    else
                    {
                        db.Entry(jobCharge).State = System.Data.Entity.EntityState.Modified;
                    }
                    db.SaveChanges();

                    return RedirectToAction("detail/" + jobCharge.jobid);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return View("Error");
            }
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpGet]
        public ActionResult EditJobCharge(int id)
        {
            var data = db.JobCharges.Find(id);
            return View(data);
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpPost]
        public ActionResult EditJobCharge(JobCharge jobCharge, int cid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    jobCharge.chargeid = cid;
                    db.Entry(jobCharge).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("detail/" + jobCharge.jobid);
                }
                catch (Exception)
                {
                    return View("error");
                }
            }
            else
            {
                return View(jobCharge);
            }
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpGet]
        public ActionResult DeleteJobCharge(int id)
        {
            var data = db.JobCharges.Find(id);
            db.JobCharges.Remove(data);
            db.SaveChanges();
            return RedirectToAction("detail/" + data.jobid);
        }

        // ---------------------- Job Management End ----------------------- //
    }
}