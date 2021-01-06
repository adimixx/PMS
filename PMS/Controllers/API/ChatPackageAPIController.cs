using Google.Cloud.Firestore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class ChatPackageAPIController : ApiController
    {
        private int StudioID
        {
            get
            {
                IEnumerable<string> StudioCredential;
                Request.Headers.TryGetValues("StudioCredential", out StudioCredential);
                int.TryParse(StudioCredential.FirstOrDefault(), out int studioID);

                return studioID;
            }
        }
        private int chatKey
        {
            get
            {
                IEnumerable<string> ChatCredential;
                Request.Headers.TryGetValues("ChatID", out ChatCredential);
                int.TryParse(ChatCredential.FirstOrDefault(), out int chatID);

                return chatID;
            }
        }

        [HttpGet]
        public IHttpActionResult GetPackageTemplate()
        {
            photogEntities db = new photogEntities();
            var charge = db.Charges.Where(x => x.StudioID == StudioID).ToList().Select((x, index) => new { x.Name, x.Price, x.Unit });

            return Ok(charge);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IHttpActionResult> PostPackageQuote(PostPackage data)
        {
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"src/json/photogw2-656bf589cae5.json"));
            FirestoreDb firestore = FirestoreDb.Create("photogw2");
            var collection = firestore.Collection("Quotation").Document(data.data);
            var snapshot = await collection.GetSnapshotAsync();
            if (!snapshot.Exists)
            {
                return BadRequest();
            }

            var deserializedData = snapshot.ConvertTo<PackageQuoteModel>();

            photogEntities db = new photogEntities();
            var chat = db.ChatKeys.FirstOrDefault(x => x.ChatKeyID == deserializedData.ChatKey);

            var job = new Job
            {
                packageid = (int)deserializedData.Package.Id,
                userid = chat.UserID,
                jobstatusid = db.JobStatus.FirstOrDefault(x => x.name.ToLower() == "quote").id,
                DateCreated = DateTime.Now
            };

            if (deserializedData.Orders != null && deserializedData.Orders.Count() != 0)
            {
                foreach (var item in deserializedData.Orders)
                {
                    job.JobCharges.Add(new JobCharge { amount = (decimal)(item.Quantity * item.PricePerUnit), remarks = item.Remarks });
                }
            }

            if (deserializedData.VenueDates != null && deserializedData.VenueDates.Count() != 0)
            {
                foreach (var item in deserializedData.VenueDates)
                {
                    job.JobDates.Add(new JobDate { jobdate1 = item.Date, location = item.Location, jobstatusid = 6 });
                }
            }

            db.Jobs.Add(job);
            db.SaveChanges();

            deserializedData.OrderStatus = "deposit";
            await collection.SetAsync(deserializedData);

            return Ok();
        }
    }   

    public class PostPackage
    {
        public string data { get; set; }
    }
}
