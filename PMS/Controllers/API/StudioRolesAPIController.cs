using Newtonsoft.Json;
using PMS.Models;
using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers.API
{
    public class StudioRolesAPIController : Controller
    {
        photogEntities db = new photogEntities();

        [HttpGet]
        [ValidateStudioAPI(RoleID = 1)]
        public string getRoleList()
        {
            int studioID = (int)TempData["StudioID"];

            var roles = db.UserStudios.ToList().Where(x => x.studioid == studioID);
            var roleAdmin = roles.Where(x => x.studioroleid == 1);
            var roleUser = roles.Where(x => x.studioroleid == 2);

            List<dynamic> dataAdmin = new List<dynamic>();
            foreach (var item in roleAdmin)
            {
                dataAdmin.Add(new
                {
                    item.User.name,
                    item.userid,
                    StudioRole = item.StudioRole.name
                });
            }

            List<dynamic> dataUser = new List<dynamic>();
            foreach (var item in roleUser)
            {
                dataUser.Add(new
                {
                    item.User.name,
                    item.userid
                });
            }

            Dictionary<string, object> replyData = new Dictionary<string, object>();
            replyData.Add("admin", dataAdmin);
            replyData.Add("user", dataUser);


            return JsonConvert.SerializeObject(replyData);
        }
    }
}