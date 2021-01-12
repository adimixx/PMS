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

        //In Development - Chat Quotation Panel
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
                var arr = new Dictionary<string, object>().ToArray();
                Dictionary<string, object> data = new Dictionary<string, object>
            {
                {"ChatKey", 1 }
            };

                var submitData = collection.Document();
                await submitData.SetAsync(data);
                docID = submitData.Id;
            }

            int studioID = (int)ViewBag.StudioID;
            ViewBag.PackageList = ent.Packages.Where(x => x.studioid == studioID).ToList();

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
        public async Task<ActionResult> ChatMain(int chatid)
        {
            ChatKey chat = ent.ChatKeys.FirstOrDefault(x => x.ChatKeyID == chatid);

            //Init Firestore - Adi
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"src/json/photogw2-656bf589cae5.json"));
            FirestoreDb firestore = FirestoreDb.Create("photogw2");
            string docID;
            var collection = firestore.Collection("Quotation");
            var snapshot = await collection.WhereEqualTo("ChatKey", chat.ChatKeyID).GetSnapshotAsync();

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

            return View(chat);
        }

        [StudioPermalinkValidate]
        public ActionResult StudioChatList()
        {
            long studioID = (long)ViewBag.StudioID;
            var chatlist = ent.ChatKeys.Where(x => x.StudioID == studioID).ToList();
            return View(chatlist);
        }


        [StudioPermalinkValidate]
        public ActionResult createchat() {            
            User whichuser = (User)UserAuthentication.Identity();
            long studioID = (long)ViewBag.StudioID;
            var checkchatkey=ent.ChatKeys.FirstOrDefault(x => x.ChatKey_Key == "studiokey"+ studioID + "userkey"+whichuser.id);
            if (checkchatkey==null ) {
                ChatKey ckforuser = new ChatKey();
                ckforuser.ChatKey_Key = "studiokey" + studioID + "userkey" + whichuser.id;
                ckforuser.UserID = whichuser.id;
                ckforuser.StudioID = null;
                ent.ChatKeys.Add(ckforuser);

                ChatKey ckforstudio = new ChatKey();
                ckforstudio.ChatKey_Key = "studiokey" + studioID + "userkey" + whichuser.id;
                ckforstudio.UserID = null;
                ckforstudio.StudioID = (int)studioID;
                ent.ChatKeys.Add(ckforstudio);

                ent.SaveChanges();
            }
            checkchatkey = ent.ChatKeys.FirstOrDefault(x => x.ChatKey_Key == "studiokey" + studioID + "userkey" + whichuser.id&&x.StudioID==null);            

            return RedirectToAction("Chatmain",new { chatid=checkchatkey.ChatKeyID});
        }


        [StudioPermalinkValidate]
        public ActionResult ChatStudioMain(int chatid)
        {
            ChatKey chat = ent.ChatKeys.FirstOrDefault(x => x.ChatKeyID == chatid);
            return View(chat);

        }


    }
}