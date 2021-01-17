using Hangfire;
using Newtonsoft.Json;
using PMS.Models;
using PMS.Models.Database;
using PMS.Models.HangFireModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class DatabaseController : Controller
    {
       [Authorize(Roles = "Admin")]
       [HttpGet]
       public ActionResult Index()
       {
            return View();
       }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> Backup()
        {
            var user = UserAuthentication.Identity();
            var obj = await DatabaseOperation.SetInitDataAsync("Backup", user.name, user.email);

            var id = (string)obj.FirstOrDefault(x => x.Key == "id").Value;
            var date = (DateTime)obj.FirstOrDefault(x => x.Key == "date").Value;

            BackgroundJob.Enqueue(() => DatabaseOperation.BackupProcessAsync(id, date));
            return RedirectToAction("Progress");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> Restore()
        {
            var user = UserAuthentication.Identity();
            var obj = await DatabaseOperation.SetInitDataAsync("Restore", user.name, user.email);

            var id = (string)obj.FirstOrDefault(x => x.Key == "id").Value;
            var date = (DateTime)obj.FirstOrDefault(x => x.Key == "date").Value;

            BackgroundJob.Enqueue(() => DatabaseOperation.RestoreProcessAsync(id, date));
            return RedirectToAction("Progress");
        }



        [HttpGet]
        public ActionResult Progress()
        {
            HangfireRecordEntities hf = new HangfireRecordEntities();

            var operation = hf.Jobs.ToList().OrderBy(x => x.Id).LastOrDefault();
            if (operation.StateName.ToLower() == "succeeded" || operation.StateName.ToLower() == "deleted")
            {
                return RedirectToAction("Index", "Database");
            }
            return View();
        }


    }
}