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
                    item.DateCreated,
                    client = item.User.name,
                    package = item.Package.name,
                    status = item.JobStatu.name,
                });
            }
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult createCheckout()
        {
            StripeConfiguration.ApiKey = "sk_test_51I0pOnBQ6wryxylDxdJO9JfTueZbork9YIz61xFNChLoDSjFZVDXozdiSsQBcP6raFNlO0u7usJopJ1UtuXfK4ZC00c44ZhQMz";
            var domain = "https://localhost:44341/payment";
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                  "fpx",
                },
                LineItems = new List<SessionLineItemOptions>
                {
                  new SessionLineItemOptions
                  {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                      UnitAmount = 2000,
                      Currency = "myr",
                      ProductData = new SessionLineItemPriceDataProductDataOptions
                      {
                        Name = "Test Packages",
                      },
                    },
                    Quantity = 1,
                  },
                },
                Mode = "payment",
                SuccessUrl = domain + "/success?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = domain + "/cancel",
            };
            var service = new SessionService();
            Session session = service.Create(options);
            return Ok(new { id = session.Id });
        }
    }
}
