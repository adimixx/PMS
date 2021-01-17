using Google.Cloud.Firestore;
using Hangfire;
using Hangfire.Storage;
using PMS.Models;
using PMS.Models.Database;
using PMS.Models.HangFireModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace PMS.Controllers.API
{
    public class DatabaseAPIController : ApiController
    {
        photogEntities db = new photogEntities();

        [AutomaticRetry(Attempts =0, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
        public async System.Threading.Tasks.Task BackupProcessAsync(int id)
        {
            db.Configuration.EnsureTransactionsForFunctionsAndCommands = false;
            var DateStart = DateTime.Now.ToUniversalTime();
            db.Database.CommandTimeout = 0;
            await db.Database.ExecuteSqlCommandAsync("exec BACKUP_AZURE");
            var DateEnd = DateTime.Now.ToUniversalTime();

            var diff = TimeSpan.FromTicks(DateEnd.Ticks - DateStart.Ticks);

            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"src/json/photogw2-656bf589cae5.json"));
            FirestoreDb firestore = FirestoreDb.Create("photogw2");
            var collection = firestore.Collection("BackupRecord").Document();
            var snapshot = await collection.GetSnapshotAsync();

            var user = db.Users.FirstOrDefault(x => x.id == id);

            var arr = new Dictionary<string, object>().ToArray();
            Dictionary<string, object> data = new Dictionary<string, object>
            {
                 {"DateStart", DateStart },
                 {"DateEnd", DateEnd },
                 {"TimeTaken", diff.TotalSeconds },
                 {"User", user.name },
                 {"Email", user.email }
            };
            await collection.SetAsync(data);
        }

        [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
        public async System.Threading.Tasks.Task RestoreProcessAsync(int id)
        {
            db.Configuration.EnsureTransactionsForFunctionsAndCommands = false;
            var DateStart = DateTime.Now.ToUniversalTime();
            db.Database.CommandTimeout = 0;
            var query = await db.Database.ExecuteSqlCommandAsync("exec RESTORE_LOCAL");
            var DateEnd = DateTime.Now.ToUniversalTime();

            var diff = TimeSpan.FromTicks(DateEnd.Ticks - DateStart.Ticks);

            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"src/json/photogw2-656bf589cae5.json"));
            FirestoreDb firestore = FirestoreDb.Create("photogw2");
            var collection = firestore.Collection("RestoreRecord").Document();
            var snapshot = await collection.GetSnapshotAsync();

            var user = db.Users.FirstOrDefault(x => x.id == id);

            var arr = new Dictionary<string, object>().ToArray();
            Dictionary<string, object> data = new Dictionary<string, object>
            {
                 {"DateStart", DateStart },
                 {"DateEnd", DateEnd },
                 {"TimeTaken", diff.TotalSeconds },
                 {"User", user.name },
                 {"Email", user.email }
            };
            await collection.SetAsync(data);
        }


        [NonAction]
        private int CheckJobStatus()
        {
            //0 - Unhandled / Error
            //1 - Success
            //2 - Processing

            var hf = new HangfireRecordEntities();
            var currJob = hf.Jobs.ToList().LastOrDefault();

            var status = currJob?.StateName?.ToLower().Trim();
            
            if (status != null)
            {
                if (status == "succeeded")
                {
                    return 1;
                }
                else if (status == "processing")
                {
                    return 2;
                }
            }          

            return 0;
        }

        [HttpGet]
        public IHttpActionResult JobStatus()
        {
            var status = CheckJobStatus();
            if (status == 1) return Ok();
            else if (status == 2) return Content(HttpStatusCode.Accepted, "Job on Progress");
            return Content(HttpStatusCode.Conflict, "Error");
        }

        [HttpGet]
        public IHttpActionResult Backup(int id)
        {
            BackgroundJob.Enqueue(() => BackupProcessAsync(id));
            return Content(HttpStatusCode.Accepted, "Backup is Started");
        }

        [HttpGet]
        public IHttpActionResult Restore(int id)
        {
            BackgroundJob.Enqueue(() => RestoreProcessAsync(id));
            return Content(HttpStatusCode.Accepted, "Restore is Started");
        }
    }
}
