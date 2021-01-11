using PMS.Models;
using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PMS.Controllers.API
{
    public class PackageImageAPIController : ApiController
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

        private int PackageID
        {
            get
            {
                IEnumerable<string> StudioCredential;
                Request.Headers.TryGetValues("Package", out StudioCredential);
                int.TryParse(StudioCredential.FirstOrDefault(), out int studioID);

                return studioID;
            }
        }

        [HttpPost]
        public IHttpActionResult Upload()
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;

            if (file != null && file.ContentLength > 0)
            {
                AzureBlob BlobManagerObj = new AzureBlob(2);
                string FileName = BlobManagerObj.UploadFileAPI(file, StudioID.ToString());
                FileName = FileName.Substring(FileName.IndexOf('/') + 1);

                photogEntities db = new photogEntities();
                PackageImage package = new PackageImage { ImageName = FileName, PackageID = PackageID };
                db.PackageImages.Add(package);
                db.SaveChanges();

                return Ok(FileName);
            }
            return BadRequest();
        }

        //[HttpPost]
        //public IHttpActionResult UploadList()
        //{
        //    var file = HttpContext.Current.Request.Files;
        //    if (file.Count > 0)
        //    {
        //        List<HttpPostedFile> httpPostedFiles = new List<HttpPostedFile>();

        //        for (int i = 0; i < file.Count; i++)
        //        {
        //            httpPostedFiles.Add(file[0]);

        //        }

        //        AzureBlob BlobManagerObj = new AzureBlob(2);
        //        List<String> filenames = BlobManagerObj.UploadMultipleFileAPI(httpPostedFiles, StudioID.ToString());

        //        photogEntities db = new photogEntities();
        //        List<PackageImage> images = filenames.Select((x, index) => new PackageImage { ImageName = x, PackageID = PackageID, IsCoverPhoto = (index == 0) }).ToList();
        //        db.PackageImages.AddRange(images);
        //        db.SaveChanges();

        //        return Ok();
        //    }         

        //    return BadRequest();
        //}

        [HttpDelete]
        public IHttpActionResult Delete(string img)
        {
            if (!string.IsNullOrWhiteSpace(img))
            {
                AzureBlob BlobManagerObj = new AzureBlob(2);
                string deletedBlob = BlobManagerObj.DeleteBlob(StudioID.ToString(), img);

                photogEntities db = new photogEntities();
                var deleted = db.PackageImages.FirstOrDefault(x => x.ImageName == deletedBlob);
                db.PackageImages.Remove(deleted);
                db.SaveChanges();

                return Ok();
            }

            return BadRequest();
        }
    }
}
