using Newtonsoft.Json;
using PMS.Models;
using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DatabaseController : Controller
    {
       [HttpGet]
       public ActionResult Index()
       {
            return View();
       }
    }
}