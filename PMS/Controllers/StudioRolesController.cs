using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class StudioRolesController : Controller
    {
        // GET: StudioUser
        [StudioPermalinkValidate]
        [StudioAuthorizationRole(RoleID = 1)]
        public ActionResult List()
        {
            return View();
        }

        [StudioPermalinkValidate]
        [StudioAuthorizationRole(RoleID = 1)]
        public ActionResult Add()
        {
            return View();
        }
    }
}