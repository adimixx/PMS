using Newtonsoft.Json;
using PMS.Models;
using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageDbController : Controller
    {
        photogEntities db;
        HttpClient client = new HttpClient();
        // GET: List of Backup DB
        //public ActionResult Index()
        //{
        //    db = new photogEntities();
        //    var list = db.DbBackupRecords.ToList();

        //    return View(list);
        //}

        [HttpGet]
        public ActionResult AddBackup()
        {
            DbBackupViewModel backup = new DbBackupViewModel();
            return View(backup);
        }

        //[HttpPost]
        //public async System.Threading.Tasks.Task<ActionResult> AddBackup(DbBackupViewModel backup)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ListDictionary items = new ListDictionary
        //        {
        //            {"storageKeyType", "StorageAccessKey"},
        //            {"storageKey", "58Fd7I3W9zl89r0TIbB4z6lmVi/zSACty3oOiJRsxUZQIq2B3/5E/RDxGNqKwU6aewS8iGxruYdKUlxMpnT0Xw=="},
        //            {"storageUri", "https://storagephotog.blob.core.windows.net/db-backup"},
        //            {"authenticationType","SQL" },
        //            {"administratorLogin","photog" },
        //            {"administratorLoginPassword","Qi^YSy#4Ae63" }
        //        };

        //        HttpResponseMessage responseMessage = await client.PostAsJsonAsync(ServerCredentials.ExportLink, items);

        //        if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
        //        {
        //            var dataName = await responseMessage.Content.ReadAsStringAsync();
        //            var dataJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(dataName);

        //            var fileName = (string)dataJson.FirstOrDefault(X => X.Key == "data").Value;

        //            DbBackupRecord newBackup = new DbBackupRecord { BackupDate = DateTime.Now, UserID = UserAuthentication.Identity().id, FileName = fileName };
        //            if (backup.SelectedBackupType == 1)
        //            {
        //                newBackup.BackupType = "Full";
        //            }

        //            db.DbBackupRecords.Add(newBackup);
        //            db.SaveChanges();
        //            TempData["BackupMessage"] = String.Format("Backup on {0} has been created successfully", newBackup.BackupDate.ToString("dd/MM/yyyy HH:mm:ss"));

        //            return RedirectToAction("Index", "Database");
        //        }
        //    }

        //    return View(backup);
        //}

        internal class ServerCredentials
        {
            const string subscriptionID = "c81acff5-05f8-4408-8c60-0c45f080c2ee";
            const string resourceGroupName = "photog";
            const string serverName = "photogdb";
            const string databaseName = "photog";
            const string apiversion = "2014-04-01";

            static public string ExportLink = string.Format("https://management.azure.com/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/databases/{3}/export?api-version={4}", subscriptionID, resourceGroupName, serverName, databaseName, apiversion);
        }
    }
}