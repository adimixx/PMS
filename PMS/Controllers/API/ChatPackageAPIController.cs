using Newtonsoft.Json;
using PMS.Models.Database;
using System;
using System.Collections.Generic;
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
        public IHttpActionResult PostNewPackage(int chatk, int PackageID)
        {
            photogEntities db = new photogEntities();
            var charge = db.ChatRooms.FirstOrDefault(x => x.ChatID == chatk);

            var package = new PackageJson
            {
                Package = db.Packages.Where(x => x.id == PackageID).ToList().Select(x => new { x.name, x.price }).FirstOrDefault()
            };
            //charge.PackageJson = JsonConvert.SerializeObject(package);
            db.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetPackageTemplate()
        {
            photogEntities db = new photogEntities();
            var charge = db.Charges.Where(x => x.StudioID == StudioID).ToList().Select((x, index) => new { x.Name, x.Price, x.Unit });
            
            return Ok(charge);
        }

        //[HttpGet]
        //public IHttpActionResult GetPackageQuotationList()
        //{
        //    photogEntities db = new photogEntities();
        //    var charge = db.ChatRooms.FirstOrDefault(x => x.ChatID == chatKey).PackageJson;

        //    var json = JsonConvert.DeserializeObject<PackageJson>(charge);

        //    return Ok(charge);
        //}

        //[HttpPost]
        //public IHttpActionResult AddPackageQuotationList(string Json)
        //{
        //    photogEntities db = new photogEntities();
        //    var charge = db.ChatRooms.FirstOrDefault(x => x.ChatID == chatKey);

        //    var PackageJson = JsonConvert.DeserializeObject<PackageJson>(Json);
        //    var convert = JsonConvert.DeserializeObject<PackageJsonOrders>(Json);
        //    PackageJson.Orders.Add(convert);
        //    charge.PackageJson = JsonConvert.SerializeObject(PackageJson);
        //    db.SaveChanges();

        //    return Ok(charge.PackageJson);

        //}

        internal class PackageJson
        {
            public dynamic Package { get; set; }
            public List<PackageJsonOrders> Orders { get; set; }
        }

        internal class PackageJsonOrders
        {
            public string Remarks { get; set; }
            public decimal PricePerUnit { get; set; }
            public string Unit { get; set; }
            public int Quantity { get; set; }
            public decimal TotalPrice { get; set; }
        }
    }
}
