using Newtonsoft.Json;
using PMS.Models;
using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PMS.Controllers.API
{
    public class StudioRolesAPIController : ApiController
    {
        [HttpGet]
        [ValidateStudioAPI(RoleID = 1)]
        public HttpResponseMessage getRoleList()
        {
            photogEntities db = new photogEntities();

            long studioID = ValidateStudioAPI.studioID;
            var roles = db.UserStudios.Where(x => x.studioid == studioID);
            var roleAdmin = roles.Where(x => x.studioroleid == 1);
            var roleUser = roles.Where(x => x.studioroleid == 2);

            List<dynamic> dataAdmin = new List<dynamic>();
            foreach (var item in roleAdmin)
            {
                dataAdmin.Add(new
                {
                    item.User.name,
                    item.userid
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


            return Request.CreateResponse(HttpStatusCode.OK, replyData);                
        }
    }
}
