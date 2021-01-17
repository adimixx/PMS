using Google.Cloud.Firestore;
using PMS.Models;
using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PMS.Controllers.API
{
    public class JobAPIController : ApiController
    {
        [HttpGet]
        public async System.Threading.Tasks.Task<IHttpActionResult> cancelJob(int id)
        {
            photogEntities db = new photogEntities();
            var job = db.Jobs.FirstOrDefault(x => x.id == id);
            var chatkey = job.Package.Studio.ChatKeys.FirstOrDefault(x => x.UserID == job.userid).ChatKeyID;
            var packageId = job.Package.id;

            if (job != null)
            {
                foreach (var item in job.Invoices.ToList())
                {
                    db.Invoices.Remove(item);
                }
                foreach (var item in job.JobCharges.ToList())
                {
                    db.JobCharges.Remove(item);
                }
                foreach (var item in job.JobDates.ToList())
                {
                    db.JobDates.Remove(item);
                }

                db.Jobs.Remove(job);
                db.SaveChanges();

                System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"src/json/photogw2-656bf589cae5.json"));
                FirestoreDb firestore = FirestoreDb.Create("photogw2");

                var collection = firestore.Collection("Quotation");
                var query = collection.WhereEqualTo("ChatKey", chatkey);
                var snapshot = await query.GetSnapshotAsync();

                var deserializedDataQuoteAll = snapshot.FirstOrDefault().ConvertTo<QuotationModel>();
                var chat = db.ChatKeys.FirstOrDefault(x => x.ChatKeyID == deserializedDataQuoteAll.ChatKey);
                var deserializedDataSel = deserializedDataQuoteAll.Packages.FirstOrDefault(x => x.Package.Id == packageId);
                deserializedDataQuoteAll.Packages.Remove(deserializedDataSel);

                await collection.Document(snapshot.FirstOrDefault().Id).SetAsync(deserializedDataQuoteAll);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
