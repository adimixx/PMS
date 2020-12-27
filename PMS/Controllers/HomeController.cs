﻿using PMS.Models;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    return View("IndexAdmin");
                }
            }

            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase uploadFile)
        {
            foreach (var file in Request.Files)
            {
                uploadFile = Request.Files[file.ToString()];
            }
            // Container Name - picture  
            AzureBlob BlobManagerObj = new AzureBlob(2);
            string FileAbsoluteUri = BlobManagerObj.UploadFile(uploadFile,"1","randomfile");
            return RedirectToAction("BlobFile");
        }

        [HttpGet]
        public ActionResult BlobFile()
        {
            // Container Name - picture  
            AzureBlob BlobManagerObj = new AzureBlob(2);
            List<string> fileList = BlobManagerObj.BlobList("1");
            return View(fileList);
        }
    }
}
