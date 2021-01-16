﻿using Google.Cloud.Firestore;
using PMS.Models;
using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    return View("IndexAdmin");
                }
            }

            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        public ActionResult Search(SearchViewModel srcres)
        {
            photogEntities db = new photogEntities();
            var a = db.Packages.Where(x => x.name.ToLower().Contains(srcres.keyword.ToLower()) && x.status == "Enabled").ToList();
            var b = db.Studios.Where(x => x.name.ToLower().Contains(srcres.keyword.ToLower())).ToList();

            if (srcres.sortby != null)
            {
                if (srcres.sortby == "pricelh")
                {
                    a = a.OrderBy(x => x.price).ToList();
                }
                else if (srcres.sortby == "pricehl")
                {
                    a = a.OrderByDescending(x => x.price).ToList();
                }
            }

            if(srcres.minprice != null)
            {
                a = a.Where(z => z.price >= decimal.Parse(srcres.minprice)).ToList();
            }

            if (srcres.maxprice != null)
            {
                a = a.Where(z => z.price <= decimal.Parse(srcres.maxprice)).ToList();
            }

            srcres.pkg = a;
            srcres.std = b;

            return View(srcres);
        }
    }
}
