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
    public class ChatController : Controller
    {
        photogEntities ent = new photogEntities();
        // GET: Chat
        [StudioPermalinkValidate]
        public async Task<ActionResult> Index()
        {
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"src/json/photogw2-656bf589cae5.json"));
            FirestoreDb firestore = FirestoreDb.Create("photogw2");
            string docID;
            var collection = firestore.Collection("Quotation");

            var snapshot = await collection.WhereEqualTo("ChatKey", 1).GetSnapshotAsync();

            if (snapshot.Count() != 0)
            {
                docID = snapshot.Documents.FirstOrDefault().Id;
            }

            else
            {
                Dictionary<string, object> data = new Dictionary<string, object>
            {
                {"ChatKey", 1 },
                {"OrderStatus", "quote"},
                {"Package", new Dictionary<string, object>
                    {
                        {"Id",1 },
                        {"Name", "PackageB" },
                        {"Price",15.00 },
                        {"Status", "active" }
                    } }
                };

                var submitData = collection.Document();
                await submitData.SetAsync(data);
                docID = submitData.Id;
            }

            ViewBag.QuotationID = docID;

            return View();
        }

        public PartialViewResult StudioChatPackagePanel()
        {
            return PartialView();
        }

        public ActionResult ChatList()
        {
            User whichuser = (User)UserAuthentication.Identity();
            var listofchatroom = ent.ChatKeys.Where(x => x.UserID == whichuser.id).ToList();

            return View(listofchatroom);
        }
        public ActionResult ChatMain(int chatid)
        {
            ChatKey chat = ent.ChatKeys.FirstOrDefault(x => x.ChatKeyID == chatid);
            return View(chat);
        }

    }
}