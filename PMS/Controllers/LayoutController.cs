using PMS.Models;
using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class LayoutController : Controller
    {
       
        public ActionResult Index()
        {
            photogEntities db = new photogEntities();
            var userid = UserAuthentication.Identity().id;

            var model = db.UserStudios.Where(x=>x.userid == userid).ToList();
            return PartialView("~/Views/Shared/_LayoutStudioList.cshtml", model);
        }
    }
}