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

        // GET: Package
        [HttpGet]
        public ActionResult PackageHome()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("addnewpackage", new CreatePackageViewModel());
        }

        [HttpPost]
        public ActionResult Create(CreatePackageViewModel data)
        {
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Packages.Find(id);
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

        [HttpPost]
        public ActionResult Edit(CreatePackageViewModel data)
        {
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

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var data = db.Packages.Find(id);
            ViewBag.user = UserAuthentication.Identity().id;
            ViewBag.role = UserAuthentication.Identity().UserSystemRoles.Any(x => x.userid == ViewBag.user && x.systemroleid == 1);
            return View("PackageDetail", data);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var package = db.Packages.FirstOrDefault(x => x.id == id);
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