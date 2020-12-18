using Newtonsoft.Json;
using PMS.Models;
using PMS.Models.Database;
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
        public IHttpActionResult loadPackages()
        {
            photogEntities db = new photogEntities();
            var model = db.Packages.ToList().Where(x => x.Studio.UserStudios.Any(y => y.userid == UserAuthentication.Identity().id)).ToList();

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
    }
}
