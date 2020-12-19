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
    public class PackageController : Controller
    {
        photogEntities db = new photogEntities();

        [StudioPermalinkValidate]
        [HttpGet]
        public ActionResult PackageHome()
        {
            return View();
        }

        [StudioPermalinkValidate]
        [HttpGet]
        public ActionResult Create()
        {
            int? studioid = ViewBag.StudioID;
            if (!db.UserStudios.ToList().Any(x => x.userid == UserAuthentication.Identity().id && x.studioid == studioid.Value))
                return View("error");

            return View("addnewpackage", new CreatePackageViewModel());
        }

        [StudioPermalinkValidate]
        [HttpPost]
        public ActionResult Create(CreatePackageViewModel data)
        {
            if (!db.UserStudios.ToList().Any(x => x.userid == UserAuthentication.Identity().id && x.studioid == data.studioid))
                return View("error");

            if (ModelState.IsValid)
            {
                try
                {
                    db.Packages.Add(new Package
                    {
                        depositprice = data.depoprice,
                        details = string.IsNullOrWhiteSpace(data.details) ? null : data.details,
                        name = data.name,
                        price = data.price,
                        studioid = data.studioid
                    });

                    db.SaveChanges();
                    return RedirectToAction("PackageHome");
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return View("addnewpackage", data);
        }

        [StudioPermalinkValidate]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Packages.Find(id);

            if (ViewBag.StudioID != data.studioid)
                return RedirectToAction("packagehome");

            if (!data.Studio.UserStudios.Any(x => x.userid == UserAuthentication.Identity().id))
                return View("error");

                var edit = new CreatePackageViewModel
            {
                depoprice = data.depositprice,
                details = data.details,
                price = data.price,
                studioid = data.studioid.Value,
                name = data.name
            };
            return View("editpackage", edit);
        }

        [StudioPermalinkValidate]
        [HttpPost]
        public ActionResult Edit(CreatePackageViewModel data)
        {
            if (ViewBag.StudioID != data.studioid)
                return RedirectToAction("packagehome");

            if (!db.UserStudios.ToList().Any(x => x.userid == UserAuthentication.Identity().id && x.studioid == data.studioid))
                return View("error");

            if (ModelState.IsValid)
            {
                try
                {
                    var edit = db.Packages.First(x => x.id == data.id);
                    edit.depositprice = data.depoprice;
                    edit.details = string.IsNullOrWhiteSpace(data.details) ? null : data.details;
                    edit.name = data.name;
                    edit.price = data.price;
                    edit.studioid = data.studioid;

                    db.SaveChanges();
                    return RedirectToAction("PackageHome");
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return View("editpackage", data);
        }

        [StudioPermalinkValidate]
        [HttpGet]
        public ActionResult Detail(int id)
        {
            var data = db.Packages.Find(id);

            if (ViewBag.StudioID != data.studioid)
                return RedirectToAction("packagehome");

            ViewBag.user = UserAuthentication.Identity().id;
            ViewBag.role = UserAuthentication.Identity().UserSystemRoles.Any(x => x.userid == ViewBag.user && x.systemroleid == 1);
            return View("PackageDetail", data);
        }

        [StudioPermalinkValidate]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var package = db.Packages.FirstOrDefault(x => x.id == id);

                if (ViewBag.StudioID != package.studioid)
                    return RedirectToAction("packagehome");

                if (package.Studio.UserStudios.Any(x => x.userid == UserAuthentication.Identity().id))
                {
                    db.Packages.Remove(package);
                    db.SaveChanges();

                    return RedirectToAction("packagehome");
                }
                else
                {
                    return View("error");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}