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

        [NonAction]
        private async Task<ActionResult> LoadChatAsync(int? key)
        {
            //ChatMain Page
            if (key.HasValue)
            {
                ChatKey chat = ent.ChatKeys.FirstOrDefault(x => x.ChatKeyID == key);
                if (chat != null) {
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
                        var arr = new Dictionary<string, object>().ToArray();
                        Dictionary<string, object> data = new Dictionary<string, object>
                        {
                            {"ChatKey", chat.ChatKeyID }
                        };
                        var submitData = collection.Document();
                        await submitData.SetAsync(data);
                        docID = submitData.Id;
                    }

                    if (ViewBag.StudioID != null)
                    {
                        int studioID = (int)ViewBag.StudioID;
                        ViewBag.PackageList = ent.Packages.Where(x => x.studioid == studioID && x.status.ToLower() != "disabled").ToList();
                    }                    
                    ViewBag.QuotationID = docID;
                    if (TempData["Package"] != null)
                    {
                        ViewBag.SelectedPackageID = TempData["Package"];
                    }
                    return View("ChatMain", chat);
                } 
            }

            //Chat List Page
            List<ChatKey> chatlist;

            if (ViewBag.StudioID != null)
            {
                long studioID = (long)ViewBag.StudioID;
                chatlist = ent.ChatKeys.Where(x => x.StudioID == studioID).ToList();
            }
            else
            {
                User whichuser = (User)UserAuthentication.Identity();
                chatlist = ent.ChatKeys.Where(x => x.UserID == whichuser.id).ToList();
            }
            
            return View("ChatList", chatlist);
        }

        //User Chat Panel
        [HttpGet]
        public async Task<ActionResult> ChatUser(int? key)
        {
            return await LoadChatAsync(key);
        }

        //Studio Chat Panel
        [StudioPermalinkValidate(RoleID = 2)]
        public async Task<ActionResult> ChatStudio(int? key)
        {
            return await LoadChatAsync(key);
        }

        [StudioPermalinkValidate]
        public ActionResult CreateChat(int? package)
        {
            User whichuser = (User)UserAuthentication.Identity();
            long studioID = (long)ViewBag.StudioID;

            var checkchatkey = ent.ChatKeys.FirstOrDefault(x => x.ChatKey_Key == "studiokey" + studioID + "userkey" + whichuser.id);
            if (checkchatkey == null)
            {
                checkchatkey = new ChatKey();
                checkchatkey.ChatKey_Key = "studiokey" + studioID + "userkey" + whichuser.id;
                checkchatkey.UserID = whichuser.id;

                checkchatkey.StudioID = (int)studioID;
                ent.ChatKeys.Add(checkchatkey);

                ent.SaveChanges();
            }

            if (package.HasValue)
            {
                TempData["Package"] = package;
            }
            return Redirect(string.Format("/{0}?key={1}", "Chat", checkchatkey.ChatKeyID));
        }

        public PartialViewResult StudioChatPackagePanel()
        {
            return PartialView();
        }
    }
}