using Google.Cloud.Firestore;
using PMS.Models;
using PMS.Models.Database;
using System;
using System.Collections.Generic;
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
        photogEntitiesLocal db = new photogEntitiesLocal();
        Thread CurrentProcess;

        public async void BackupProcess()
        {
            photogEntitiesLocal db = new photogEntitiesLocal();
            db.Configuration.EnsureTransactionsForFunctionsAndCommands = false;
            var DateStart = DateTime.Now.ToUniversalTime();
            db.BACKUP_AZURE();
            var DateEnd = DateTime.Now.ToUniversalTime();

            var diff = TimeSpan.FromTicks(DateEnd.Ticks - DateStart.Ticks);

            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"src/json/photogw2-656bf589cae5.json"));
            FirestoreDb firestore = FirestoreDb.Create("photogw2");
            var collection = firestore.Collection("BackupRecord").Document();
            var snapshot = await collection.GetSnapshotAsync();

            var arr = new Dictionary<string, object>().ToArray();
            Dictionary<string, object> data = new Dictionary<string, object>
            {
                 {"DateStart", DateStart },
                 {"DateEnd", DateEnd },
                 {"TimeTaken", diff.TotalSeconds },
                 {"User", UserAuthentication.Identity().name },
                 {"Email", UserAuthentication.Identity().email }
            };
            await collection.SetAsync(data);
        }

        public async void RestoreProcess()
        {
            photogEntitiesLocal db = new photogEntitiesLocal();
            db.Configuration.EnsureTransactionsForFunctionsAndCommands = false;
            var DateStart = DateTime.Now;
            db.RESTORE_LOCAL();
            var DateEnd = DateTime.Now;

            var diff = TimeSpan.FromTicks(DateEnd.Ticks - DateStart.Ticks);

            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"src/json/photogw2-656bf589cae5.json"));
            FirestoreDb firestore = FirestoreDb.Create("photogw2");
            var collection = firestore.Collection("RestoreRecord").Document();
            var snapshot = await collection.GetSnapshotAsync();

            var arr = new Dictionary<string, object>().ToArray();
            Dictionary<string, object> data = new Dictionary<string, object>
            {
                 {"DateStart", DateStart },
                 {"DateEnd", DateEnd },
                 {"TimeTaken", diff.TotalSeconds },
                 {"User", UserAuthentication.Identity().name },
                 {"Email", UserAuthentication.Identity().email }
            };
            await collection.SetAsync(data);
        }

        [HttpGet]
        public IHttpActionResult BackupStatus()
        {
            if (CurrentProcess.IsAlive)
            {
                return Content(HttpStatusCode.Accepted, "Backup is still Ongoing");
            }
            return Ok("Backup Done");
        }


        [HttpGet]
        public IHttpActionResult Backup()
        {
            CurrentProcess = new Thread(x=> BackupProcess());
            CurrentProcess.Start();
            return Content(HttpStatusCode.Accepted, "Backup is Started");
        }

        [HttpGet]
        public IHttpActionResult Restore()
        {
            CurrentProcess = new Thread(x => RestoreProcess());
            CurrentProcess.Start();
            return Content(HttpStatusCode.Accepted, "Restore is Started");
        }
    }
}
