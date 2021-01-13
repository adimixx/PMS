using PMS.Models;
using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    [Authorize]
    public class ChatStudioController : Controller
    {
        photogEntities ent = new photogEntities();

        [StudioPermalinkValidate(RoleID = 2)]
        public ActionResult Index(int? key)
        {
            if (key.HasValue)
            {
                ChatKey chat = ent.ChatKeys.FirstOrDefault(x => x.ChatKeyID == key);
                if (chat != null) return View("~/Views/Chat/ChatMain.cshtml", chat);
            }

            long studioID = (long)ViewBag.StudioID;
            var chatlist = ent.ChatKeys.Where(x => x.StudioID == studioID).ToList();            
            return View("~/Views/Chat/ChatList.cshtml", chatlist);
        }

        [StudioPermalinkValidate]
        public ActionResult CreateChat()
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

            return Redirect(string.Format("/{0}?key={1}", "Chat", checkchatkey.ChatKeyID));
        }
    }
}