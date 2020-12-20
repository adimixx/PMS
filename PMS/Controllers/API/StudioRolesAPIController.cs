using PMS.Models;
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
            long studioID = TempData["StudioID"];
            return null; 
        }
    }
}
