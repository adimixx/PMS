﻿using PMS.Models;
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
                catch (Exception e)
                {
                    return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
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
                catch (Exception e)
                {
                    return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
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
            catch (Exception e)
            {
                return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
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

        [HttpGet]
        public ActionResult JobCustomer()
        {
            return View();
        }

        [HttpGet]
        public ActionResult JobCustomerDetail(int id)
        {
            try
            {
                var job = db.Jobs.Find(id);
                //var jobdate = job != null ? db.JobDates.Where(x => x.jobid == id).ToList() : null;
                //var jobdateuser = jobdate != null ? db.JobDateUsers.Where(x => x.JobDate.jobid == job.id).ToList() : null;
                //var jobcharge = job != null ? db.JobCharges.FirstOrDefault(x => x.jobid == id) : null;

                if (job.userid != UserAuthentication.Identity().id)
                    return Redirect("/");

                ViewBag.StudioUrl = job.Package.Studio.uniquename;
                return View("detail", job);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
            }
        }

        [StudioPermalinkValidate]
        [HttpGet]
        public ActionResult Detail(int id)
        {
            try
            {
                var job = db.Jobs.Find(id);
                //var jobdate = job != null ? db.JobDates.Where(x => x.jobid == id).ToList() : null;
                //var jobdateuser = jobdate != null ? db.JobDateUsers.Where(x => x.JobDate.jobid == job.id).ToList() : null;
                //var jobcharge = job != null ? db.JobCharges.FirstOrDefault(x => x.jobid == id) : null;

                if (ViewBag.StudioID != job.Package.studioid)
                    return RedirectToAction("jobhome");

                var identity = UserAuthentication.Identity();
                if (!db.Jobs.Any(x => x.userid == identity.id && x.id == id) && ViewBag.StudioRoleID == null)
                    return Redirect("/");

                return View(job);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
            }
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
            catch (Exception e)
            {
                return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
            }
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpGet]
        public ActionResult ChangeDate(int id)
        {
            try
            {
                var job = db.JobDates.Find(id);
                return View(job);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
            }
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpPost]
        public ActionResult ChangeDate(JobDate job, DateTime jobdate, TimeSpan jobtime)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    job.jobstatusid = 6;
                    job.jobdate1 = jobdate.Add(jobtime);
                    db.Entry(job).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("detail/" + job.jobid);
                }
                catch (Exception e)
                {
                    return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
                }
            }
            else
                return RedirectToAction("Error500", "Home", new { errormsg = "There is an error processing your input/request!" });
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpGet]
        public ActionResult AssignStaff(int id, int jobid)
        {
            try
            {
                var jdu = new JobDateUser();
                int stuid = ViewBag.StudioID;
                jdu.userstudioid = db.UserStudios.FirstOrDefault(x => x.userid == id && x.studioid == stuid).id;
                ViewBag.dropdown = db.JobDates.Where(x => x.jobid == jobid).ToList().Select(x => new SelectListItem
                {
                    Text = x.jobdate1.ToString("dd/MM/yyyy hh:mm tt"),
                    Value = x.id.ToString()
                });
                return View(jdu);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
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
                    var date = db.JobDates.FirstOrDefault(x => x.id == jobDateUser.jobdateid)?.jobdate1.Date;
                    if (db.JobDateUsers.ToList().Any(x => x.JobDate.jobdate1.Date == date && x.userstudioid == jobDateUser.userstudioid))
                    {
                        return RedirectToAction("Error500", "Home", new { errormsg = "Staff is busy on that date!" });
                    }

                    db.JobDateUsers.Add(jobDateUser);
                    db.SaveChanges();

                    return RedirectToAction("detail/" + db.JobDates.FirstOrDefault(x => x.id == jobDateUser.jobdateid).jobid);
                }
                catch (Exception e)
                {
                    return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
                }
            }
            else
            {
                return RedirectToAction("Error500", "Home", new { errormsg = "There is an error processing your input/request!" });
            }
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpGet]
        public ActionResult deleteJobStaff(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var jobDateUser = db.JobDateUsers.Find(id);
                    var jobid = jobDateUser.JobDate.jobid;
                    db.JobDateUsers.Remove(jobDateUser);
                    db.SaveChanges();

                    return RedirectToAction("detail/" + jobid);
                }
                catch (Exception e)
                {
                    return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
                }
            }
            else
            {
                return RedirectToAction("Error500", "Home", new { errormsg = "There is an error processing your input/request!" });
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
                    if (jobCharge.id == 0)
                    {
                        db.JobCharges.Add(jobCharge);
                    }
                    else
                    {
                        db.Entry(jobCharge).State = System.Data.Entity.EntityState.Modified;
                    }
                    db.SaveChanges();

                    if (jobCharge.Job.Invoices.Any(x => x.detail == "Charge Payment"))
                    {
                        var invoice = db.Invoices.FirstOrDefault(x => x.jobid == jobCharge.jobid && x.detail == "Charge Payment");
                        invoice.total += jobCharge.amount;
                        invoice.totalunpaid += jobCharge.amount;
                        db.SaveChanges();
                    }

                    return RedirectToAction("detail/" + jobCharge.jobid);
                }
                catch (Exception e)
                {
                    return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
                }
            }
            else
            {
                return RedirectToAction("Error500", "Home", new { errormsg = "There is an error processing your input/request!" });
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
                    db.Entry(jobCharge).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    if (jobCharge.Job.Invoices.Any(x => x.detail == "Charge Payment"))
                    {
                        var invoice = db.Invoices.FirstOrDefault(x => x.jobid == jobCharge.jobid && x.detail == "Charge Payment");
                        invoice.total = db.JobCharges.Where(x => x.jobid == jobCharge.jobid).Sum(x => x.amount);
                        invoice.totalunpaid = db.JobCharges.Where(x => x.jobid == jobCharge.jobid).Sum(x => x.amount) - (invoice.total - invoice.totalunpaid);
                        db.SaveChanges();
                    }

                    return RedirectToAction("detail/" + jobCharge.jobid);
                }
                catch (Exception e)
                {
                    return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
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
            try
            {
                var data = db.JobCharges.Find(id);
                var jobid = data.jobid;

                if (data.Job.Invoices.Any(x => x.detail == "Charge Payment"))
                {
                    var invoice = db.Invoices.FirstOrDefault(x => x.jobid == data.jobid && x.detail == "Charge Payment");
                    invoice.total -= data.amount;
                    invoice.totalunpaid -= data.amount;
                    db.SaveChanges();
                }

                db.JobCharges.Remove(data);
                db.SaveChanges();
                return RedirectToAction("detail/" + jobid);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
            }
        }

        // ---------------------- Job Management End ----------------------- //

        // ---------------------- Invoice Management Start ---------------------- //

        [StudioPermalinkValidate]
        [HttpGet]
        public ActionResult PaymentView(int id)
        {
            try
            {
                ViewBag.jobid = id;
                ViewBag.hasDeposit = db.Invoices.Any(x => x.jobid == id && x.status == "Paid" && x.detail == "Deposit");
                ViewBag.hasFull = db.Invoices.Any(x => x.jobid == id && x.detail == "Full Payment");
                var uid = UserAuthentication.Identity().id;
                ViewBag.isJobClient = db.Jobs.Any(x => x.id == id && x.userid == uid);
                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
            }
        }

        [StudioPermalinkValidate]
        [HttpGet]
        public ActionResult CreateDepositInvoice(int id)
        {
            try
            {
                var job = db.Jobs.Find(id);

                if (job.Package.depositprice <= 0)
                {
                    TempData["error"] = "There is no deposit amount set for this package";
                    return Redirect(Request.UrlReferrer.ToString());
                }

                var invoice = new Invoice
                {
                    expirydate = DateTime.Now.AddMonths(3),
                    invdate = DateTime.Now,
                    jobid = id,
                    total = job.Package.depositprice,
                    totalunpaid = job.Package.depositprice,
                    detail = "Deposit",
                    status = "Not Paid",
                };
                db.Invoices.Add(invoice);
                db.SaveChanges();

                return RedirectToAction("checkoutindex/" + invoice.id, "Payment");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
            }
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpGet]
        public ActionResult CreateChargeInvoice(int id)
        {
            try
            {
                var job = db.Jobs.Find(id);
                var chargeamount = db.JobCharges.Where(x => x.jobid == id).Sum(x => x.amount);
                db.Invoices.Add(new Invoice
                {
                    expirydate = DateTime.Now.AddMonths(3),
                    invdate = DateTime.Now,
                    jobid = id,
                    total = chargeamount,
                    totalunpaid = chargeamount,
                    detail = "Charge Payment",
                    status = "Not Paid",
                });
                db.SaveChanges();

                return RedirectToAction("paymentview/" + id);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
            }
        }

        [StudioPermalinkValidate]
        [HttpGet]
        public ActionResult CreateFullInvoice(int id)
        {
            try
            {
                var job = db.Jobs.Find(id);
                if (job.Invoices.Any(x => x.detail == "Deposit" && x.status == "Paid"))
                {
                    var invoice = new Invoice
                    {
                        expirydate = DateTime.Now.AddMonths(3),
                        invdate = DateTime.Now,
                        jobid = id,
                        total = (job.TotalPrice) - job.Package.depositprice,
                        totalunpaid = (job.TotalPrice) - job.Package.depositprice,
                        detail = "Full Payment",
                        status = "Not Paid",
                    };
                    db.Invoices.Add(invoice);
                    db.SaveChanges();

                    var uid = UserAuthentication.Identity().id;
                    if (ViewBag.StudioRoleID != null && !db.Jobs.Any(x => x.id == id && x.userid == uid))
                    {
                        return RedirectToAction("paymentview/" + invoice.jobid);
                    }
                    else
                    {
                        return RedirectToAction("checkoutindex/" + invoice.id, "payment");
                    }
                }
                else
                {
                    var invoice = new Invoice
                    {
                        expirydate = DateTime.Now.AddMonths(3),
                        invdate = DateTime.Now,
                        jobid = id,
                        total = job.TotalPrice,
                        totalunpaid = job.TotalPrice,
                        detail = "Full Payment",
                        status = "Not Paid",
                    };
                    db.Invoices.Add(invoice);
                    db.SaveChanges();

                    var uid = UserAuthentication.Identity().id;
                    if (ViewBag.StudioRoleID != null && !db.Jobs.Any(x => x.id == id && x.userid == uid))
                    {
                        return RedirectToAction("paymentview/" + invoice.jobid);
                    }
                    else
                    {
                        return RedirectToAction("checkoutindex/" + invoice.id, "payment");
                    }
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
            }
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpGet]
        public ActionResult deleteInvoice(int id)
        {
            try
            {
                var data = db.Invoices.Find(id);
                var jid = data.jobid;
                db.Invoices.Remove(data);
                db.SaveChanges();
                return RedirectToAction("paymentview/" + jid);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
            }
        }

        // ---------------------- Invoice Management End ---------------------- //
    }
}