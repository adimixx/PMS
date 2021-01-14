using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PMS.Controllers.API
{
    public class JobAPIController : ApiController
    {
        [HttpGet]
        public IHttpActionResult cancelJob(int id)
        {
            photogEntities db = new photogEntities();
            var job = db.Jobs.FirstOrDefault(x => x.id == id);

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

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
