using PMS.Models;
using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class ChatController : Controller
    {
        photogEntities ent = new photogEntities();
        // GET: Chat
        [StudioPermalinkValidate]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult StudioChatPackagePanel()
        {
            return PartialView();
        }

        public ActionResult ChatList() {
            User whichuser = (User)UserAuthentication.Identity();
            var listofchatroom = ent.ChatKeys.Where(x=>x.UserID==whichuser.id).ToList();
            
            return View(listofchatroom);
        }
        public ActionResult ChatMain(int chatid) {
            ChatKey chat = ent.ChatKeys.FirstOrDefault(x => x.ChatKeyID == chatid);
            return View(chat);
        }
        

    }
}