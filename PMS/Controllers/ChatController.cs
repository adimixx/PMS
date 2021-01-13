using Google.Cloud.Firestore;
using PMS.Models;
using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        photogEntities ent = new photogEntities();

        public ActionResult Index(int? key)
        {
            if (key.HasValue)
            {
                ChatKey chat = ent.ChatKeys.FirstOrDefault(x => x.ChatKeyID == key);
                if (chat != null) return View("~/Views/Chat/ChatMain.cshtml", chat);
            }

            User whichuser = (User)UserAuthentication.Identity();
            var listofchatroom = ent.ChatKeys.Where(x => x.UserID == whichuser.id).ToList();

            return View("~/Views/Chat/ChatList.cshtml", listofchatroom);
        }

        //In Development - Chat Quotation Panel
        //[StudioPermalinkValidate]
        //public async Task<ActionResult> Index()
        //{
        //    System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"src/json/photogw2-656bf589cae5.json"));
        //    FirestoreDb firestore = FirestoreDb.Create("photogw2");
        //    string docID;
        //    var collection = firestore.Collection("Quotation");

        //    var snapshot = await collection.WhereEqualTo("ChatKey", 1).GetSnapshotAsync();

        //    if (snapshot.Count() != 0)
        //    {
        //        docID = snapshot.Documents.FirstOrDefault().Id;
        //    }

        //    else
        //    {
        //        var arr = new Dictionary<string, object>().ToArray();
        //        Dictionary<string, object> data = new Dictionary<string, object>
        //    {
        //        {"ChatKey", 1 }
        //    };

        //        var submitData = collection.Document();
        //        await submitData.SetAsync(data);
        //        docID = submitData.Id;
        //    }

        //    int studioID = (int)ViewBag.StudioID;
        //    ViewBag.PackageList = ent.Packages.Where(x => x.studioid == studioID).ToList();

        //    ViewBag.QuotationID = docID;
        //    return View();
        //}

        //public PartialViewResult StudioChatPackagePanel()
        //{
        //    return PartialView();
        //}


    }
}