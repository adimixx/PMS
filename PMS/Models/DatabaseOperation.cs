﻿using Google.Cloud.Firestore;
using Hangfire;
using PMS.Models.Database;
using PMS.Models.HangFireModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PMS.Models
{
    public class DatabaseOperation : ActionFilterAttribute
    {
        static photogEntities db = new photogEntities();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                HangfireRecordEntities hf = new HangfireRecordEntities();

                string url = HttpContext.Current.Request.ApplicationPath.ToLower();
                var operation = hf.Jobs.ToList().OrderBy(x => x.Id).LastOrDefault();

                if (operation != null)
                {
                    if (operation.StateName.ToLower() != "succeeded" && operation.StateName.ToLower() != "deleted")
                    {
                        if (HttpContext.Current.User.IsInRole("Admin"))
                        {
                            if (url.ToLower() != "hangfire")
                            {
                                filterContext.Result = new ViewResult
                                {
                                    ViewName = "~/Views/Database/Progress.cshtml"
                                };
                            }
                        }

                        else
                        {
                            filterContext.HttpContext.Response.Clear();
                            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                            filterContext.HttpContext.Response.StatusDescription = "Database Maintenance";
                            filterContext.Result = new ViewResult
                            {
                                ViewName = "~/Views/Shared/Maintenance.cshtml"
                            };
                        }
                    }
                }
            }
            catch
            {

            }
          
            
            base.OnActionExecuting(filterContext);
        }

        private static async Task DbOperationASync(string proc, string id, DateTime DateStart)
        {        
            db.Database.CommandTimeout = 0;
            db.Configuration.EnsureTransactionsForFunctionsAndCommands = false;
            await db.Database.ExecuteSqlCommandAsync(proc);
            var DateEnd = DateTime.Now.ToUniversalTime();
            var diff = TimeSpan.FromTicks(DateEnd.Ticks - DateStart.Ticks);

            FirestoreDb firestore = FirestoreDb.Create("photogw2");

            var collection = firestore.Collection("BackupRestoreRecord").Document(id);
            var snapshot = await collection.GetSnapshotAsync();
            Dictionary<string, object> data = new Dictionary<string, object>
            {
                 {"DateEnd", DateEnd },
                 {"TimeTaken", diff.TotalSeconds }
            };
            await collection.SetAsync(data, SetOptions.MergeAll);
        }

        public static async Task<Dictionary<string, object>> SetInitDataAsync(string type, string name, string email)
        {
            FirestoreDb firestore = FirestoreDb.Create("photogw2");

            var collection = firestore.Collection("BackupRestoreRecord").Document();
            var snapshot = await collection.GetSnapshotAsync();
            var DateStart = DateTime.Now.ToUniversalTime();

            Dictionary<string, object> data = new Dictionary<string, object>
            {
                 {"DateStart", DateStart },
                 {"User", name },
                 {"Email", email },
                 {"Type", type}
            };
            await collection.SetAsync(data);

            return new Dictionary<string, object>
            {
                 {"id", collection.Id },
                 {"date", DateStart }
            };
        }


        [AutomaticRetry(Attempts = 3, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
        public static async System.Threading.Tasks.Task BackupProcessAsync(string id, DateTime DateStart)
        {
            await DbOperationASync("exec BACKUP_AZURE", id, DateStart);            
        }

        [AutomaticRetry(Attempts = 3, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
        public static async System.Threading.Tasks.Task RestoreProcessAsync(string id, DateTime DateStart)
        {
            await DbOperationASync("exec RESTORE_LOCAL @WHERE_TABLES = ''", id, DateStart);
        }
    }
}