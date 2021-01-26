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
            return Content(HttpStatusCode.Accepted, "Backup is Started");
        }

        [HttpGet]
        public IHttpActionResult Restore(int id)
        {
            return Content(HttpStatusCode.Accepted, "Restore is Started");
        }

        [HttpGet]
        public IHttpActionResult GetBlobList()
        {
            var blob = new AzureBlob(3);

            var reply = blob.GetBlobList().Select(x => new { name = x, url = String.Format("https://storagephotog2.blob.core.windows.net/db-backup/{0}", x) });

            return Ok(reply);
        }
    }
}
