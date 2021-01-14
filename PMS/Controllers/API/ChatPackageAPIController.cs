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

        [HttpGet]
        public IHttpActionResult GetPackageDetails(int id)
        {
            photogEntities db = new photogEntities();
            var charge = db.Packages.FirstOrDefault(x => x.id == id);

            return Ok(new Package { id = charge.id, depositprice = charge.depositprice, details = charge.details, name = charge.name, price = charge.price});
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

            var deserializedDataQuoteAll = snapshot.ConvertTo<QuotationModel>();

            photogEntities db = new photogEntities();
            int package = Convert.ToInt32(data.package);
            var chat = db.ChatKeys.FirstOrDefault(x => x.ChatKeyID == deserializedDataQuoteAll.ChatKey);
            var deserializedDataSel = deserializedDataQuoteAll.Packages.Select((x, index) => new { x, index }).FirstOrDefault(x => x.x.Package.Id == package);
            var deserializedData = deserializedDataSel.x;

            var job = new Job
            {
                packageid = (int)deserializedData.Package.Id,
                userid = chat.UserID,
                jobstatusid = db.JobStatus.FirstOrDefault(x => x.name.ToLower() == "pending deposit").id,
                DateCreated = DateTime.Now,    
                PackagePrice = Decimal.Parse(deserializedData.Package.Price.ToString()),
                TotalPrice = decimal.Parse((deserializedData.Charges.Sum(x=> (x.Quantity * x.PricePerUnit)) + deserializedData.Package.Price).ToString())
            };

            if (deserializedData.Charges != null && deserializedData.Charges.Count() != 0)
            {
                foreach (var item in deserializedData.Charges)
                {
                    job.JobCharges.Add(new JobCharge { amount = (decimal)(item.Quantity * item.PricePerUnit), remarks = item.Remarks });
                }
            }

            if (deserializedData.Venues != null && deserializedData.Venues.Count() != 0)
            {
                foreach (var item in deserializedData.Venues)
                {
                    job.JobDates.Add(new JobDate { jobdate1 = item.Date, location = item.Location, jobstatusid = 6 });
                }
            }

            db.Jobs.Add(job);
            db.SaveChanges();

            deserializedData.OrderStatus = job.JobStatu.name;
            deserializedData.JobLink = string.Format("/{0}/job/detail/{1}", chat.Studio.uniquename, job.id.ToString());

            deserializedDataQuoteAll.Packages[deserializedDataSel.index] = deserializedData;
            
            await collection.SetAsync(deserializedDataQuoteAll);
            return Ok();
        }

        
    }   

    public class PostPackage
    {
        public string data { get; set; }
        public string package { get; set; }
    }
}
