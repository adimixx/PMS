using PMS.Models;
using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PMS.Controllers.API
{
    public class StudioAPIController : ApiController
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

        [HttpPost]
        public IHttpActionResult UploadProfilePic()
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            photogEntities db = new photogEntities();
            var studio = db.Studios.FirstOrDefault(x => x.id == StudioID);

            if (file != null && file.ContentLength > 0)
            {
                AzureBlob BlobManagerObj = new AzureBlob(4);
                string FileName = BlobManagerObj.UploadFileAPI(file, null);
                FileName = FileName.Substring(FileName.IndexOf('/') + 1);
                return Ok(FileName);
            }
            return BadRequest();
        }

        [HttpPost]
        public IHttpActionResult UploadCoverPic()
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            photogEntities db = new photogEntities();
            var studio = db.Studios.FirstOrDefault(x => x.id == StudioID);

            if (file != null && file.ContentLength > 0)
            {
                AzureBlob BlobManagerObj = new AzureBlob(4);

                string FileName = BlobManagerObj.UploadFileAPI(file, null);
                FileName = FileName.Substring(FileName.IndexOf('/') + 1);
                return Ok(FileName);
            }
            return BadRequest();
        }
    }
}
