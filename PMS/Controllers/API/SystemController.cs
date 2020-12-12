using Newtonsoft.Json;
using PMS.Models;
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
    }
}
