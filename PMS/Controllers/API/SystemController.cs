using Newtonsoft.Json;
using PMS.Models;
using PMS.Models.Database;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PMS.Controllers
{
    public class SystemController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage getCity(string state)
        {
            if (string.IsNullOrWhiteSpace(state)) return Request.CreateResponse(HttpStatusCode.BadRequest);

            LocationList location = new LocationList();

            var list = location.Cities.Where(x => x.Key.ToLower() == state.ToLower().Trim());

            if (list.Count() == 0 && !location.Cities.FirstOrDefault(x => x.Key.ToLower() == state.ToLower().Trim()).Equals(null)) return Request.CreateResponse(HttpStatusCode.OK);

            else if (list.Count() == 0) return Request.CreateResponse(HttpStatusCode.BadRequest);


            var listStripped = list.Select(x => x.Value).ToArray().FirstOrDefault();

            return Request.CreateResponse(HttpStatusCode.OK, listStripped);
        }

        [HttpGet]
        public IHttpActionResult loadPackages(int id)
        {
            photogEntities db = new photogEntities();
            var model = db.Packages.Where(x => x.studioid == id).ToList();

            List<dynamic> data = new List<dynamic>();
            foreach (var item in model)
            {
                data.Add(new
                {
                    item.id,
                    item.name,
                    price = item.price.ToString(".00"),
                    studioname = item.Studio.name,
                    depositprice = item.depositprice.ToString(".00"),
                    item.details
                });
            }
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult loadJobStatus()
        {
            photogEntities db = new photogEntities();
            var model = db.JobStatus.ToList();

            List<dynamic> data = new List<dynamic>();
            foreach (var item in model)
            {
                data.Add(new
                {
                    item.id,
                    item.name,
                });
            }
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult loadJobAdmin(int id)
        {
            photogEntities db = new photogEntities();
            var model = db.Jobs.Where(x => x.Package.studioid == id).ToList();

            List<dynamic> data = new List<dynamic>();
            foreach (var item in model)
            {
                data.Add(new
                {
                    item.id,
                    DateCreated = item.DateCreated.ToString("dd/MM/yyyy hh:mm"),
                    client = item.User.name,
                    package = item.Package.name,
                    status = item.JobStatu.name,
                    paymentstatus = item.Invoices.Any() ? item.Invoices.OrderByDescending(x => x.id).FirstOrDefault(x => x.jobid == item.id).status : "-",
                    paymentdetail = item.Invoices.Any() ? item.Invoices.OrderByDescending(x => x.id).FirstOrDefault(x => x.jobid == item.id).detail : "-"
                });
            }
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult loadJobCustomer()
        {
            photogEntities db = new photogEntities();
            var aid = UserAuthentication.Identity().id;
            var model = db.Jobs.Where(x => x.userid == aid).ToList();

            List<dynamic> data = new List<dynamic>();
            foreach (var item in model)
            {
                data.Add(new
                {
                    item.id,
                    DateCreated = item.DateCreated.ToString("dd/MM/yyyy hh:mm"),
                    client = item.User.name,
                    package = item.Package.name,
                    status = item.JobStatu.name,
                    paymentstatus = item.Invoices.Any() ? item.Invoices.OrderByDescending(x => x.id).FirstOrDefault(x => x.jobid == item.id).status : "-",
                    paymentdetail = item.Invoices.Any() ? item.Invoices.OrderByDescending(x => x.id).FirstOrDefault(x => x.jobid == item.id).detail : "-",
                    studiolink = item.Package.Studio.uniquename
                });
            }
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult loadJobCharges(int id)
        {
            photogEntities db = new photogEntities();
            var model = db.JobCharges.Where(x => x.jobid == id).ToList();

            List<dynamic> data = new List<dynamic>();
            foreach (var item in model)
            {
                data.Add(new
                {
                    item.id,
                    amount = "RM" + item.amount.ToString(".00"),
                    item.remarks
                });
            }
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult loadJobStaff(int id)
        {
            photogEntities db = new photogEntities();
            var model = db.JobDateUsers.Where(x => x.jobdateid == id).ToList();

            List<dynamic> data = new List<dynamic>();
            foreach (var item in model)
            {
                data.Add(new
                {
                    item.UserStudio.User.name,
                    item.UserStudio.User.email,
                    phone = item.UserStudio.User.phonenumber,
                    item.id
                });
            }
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult loadCharges(int id)
        {
            photogEntities db = new photogEntities();
            var model = db.Charges.Where(x => x.StudioID == id).ToList();

            List<dynamic> data = new List<dynamic>();
            foreach (var item in model)
            {
                data.Add(new
                {
                    item.id,
                    item.Name,
                });
            }
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult loadInvoices(int id)
        {
            photogEntities db = new photogEntities();
            var model = db.Invoices.Where(x => x.jobid == id).ToList();

            List<dynamic> data = new List<dynamic>();
            foreach (var item in model)
            {
                data.Add(new
                {
                    item.id,
                    invdate = item.invdate.ToString("dd/MM/yyyy"),
                    expirydate = item.expirydate.ToString("dd/MM/yyyy"),
                    item.total,
                    item.totalunpaid,
                    item.detail,
                    item.status
                });
            }
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult loadSearch(string keyword)
        {
            photogEntities db = new photogEntities();
            var model = db.Packages.Where(x => x.name.Contains(keyword)).ToList();

            List<dynamic> data = new List<dynamic>();

            foreach (var item in model)
            {
                data.Add(new
                {
                    item.id,
                    item.name,
                    price = item.price.ToString(".00"),
                    studioname = item.Studio.name,
                    depositprice = item.depositprice.ToString(".00"),
                    item.details
                });
            }

            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult loadSearchStudio(string keyword)
        {
            photogEntities db = new photogEntities();
            var model = db.Studios.Where(x => x.name.Contains(keyword)).ToList();

            List<dynamic> data = new List<dynamic>();

            foreach (var item in model)
            {
                data.Add(new
                {
                    item.id,
                    item.name,
                    item.State,
                    item.City,
                    item.ImgLogo,
                    item.ImgCover,
                    item.shortDesc,
                    item.uniquename
                });
            }

            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult loadSearchPackageImg(int id)
        {
            photogEntities db = new photogEntities();
            var model = db.PackageImages.Where(x => x.PackageID == id).ToList();
            var model2 = db.Studios
                         .Join(db.Packages, std => std.id, pkg => pkg.studioid, (std, pkg) => new { std, pkg })
                         .Join(db.PackageImages, ppkg => ppkg.pkg.id, pkgi => pkgi.PackageID, (ppkg, pkgi) => new { ppkg, pkgi })
                         .Where(x => x.pkgi.PackageID == id).ToList();

            List<dynamic> data = new List<dynamic>();

            foreach (var item in model2)
            {
                data.Add(new
                {
                    item.ppkg.std.id,
                    item.ppkg.std.name,
                    item.ppkg.std.shortDesc,
                    item.pkgi.ID,
                    item.pkgi.ImageName,
                    item.pkgi.PackageID
                });
            }

            return Ok(data);
        }
    }
}
