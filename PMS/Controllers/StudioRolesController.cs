using PMS.Models;
using PMS.Models.Database;
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
        [StudioPermalinkValidate(RoleID = 1)]
        public ActionResult List()
        {
            return View();
        }

        [StudioPermalinkValidate(RoleID = 1)]
        public ActionResult Add()
        {
            return View();
        }       
    }
}