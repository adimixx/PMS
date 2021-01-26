using AutoMapper;
using Google.Cloud.Firestore;
using PMS.Models;
using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    [Authorize]
    public class PackageController : Controller
    {
        photogEntities db = new photogEntities();

        [StudioPermalinkValidate(RoleID = 2)]
        [HttpGet]
        public ActionResult PackageHome()
        {
            return View();
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpGet]
        public ActionResult Create()
        {
            int? studioid = ViewBag.StudioID;
            if (!db.UserStudios.ToList().Any(x => x.userid == UserAuthentication.Identity().id && x.studioid == studioid.Value))
                return RedirectToAction("Error500", "Home", new { errormsg = "You picked the wrong studio Fool!" });

            return View("editpackage", new CreatePackageViewModel());
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpPost]
        public ActionResult Create(CreatePackageViewModel data)
        {
            if (!db.UserStudios.ToList().Any(x => x.userid == UserAuthentication.Identity().id && x.studioid == data.studioid))
                return RedirectToAction("Error500", "Home", new { errormsg = "You picked the wrong studio Fool!" });

            if (ModelState.IsValid)
            {
                try
                {
                    if (data.price < data.depoprice || data.price <= 0 || data.depoprice < 0)
                    {
                        TempData["error"] = "Invalid price setting";
                        return View("editpackage", data);
                    }

                    var pack = new Package
                    {
                        depositprice = data.depoprice,
                        details = string.IsNullOrWhiteSpace(data.details) ? null : data.details,
                        name = data.name,
                        price = data.price,
                        studioid = data.studioid,
                        status = "Enabled"
                    };

                    if (!string.IsNullOrWhiteSpace(data.ImgName))
                    {
                        PackageImage package = new PackageImage { ImageName = data.ImgName};
                        pack.PackageImages.Add(package);
                    }

                    db.Packages.Add(pack);
                    db.SaveChanges();
                    return RedirectToAction("PackageHome");
                }
                catch (Exception e)
                {
                    return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
                }
            }

            return View("editpackage", data);
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Packages.Find(id);

            if (ViewBag.StudioID != data.studioid)
                return RedirectToAction("packagehome");

            if (!data.Studio.UserStudios.Any(x => x.userid == UserAuthentication.Identity().id))
                return RedirectToAction("Error500", "Home", new { errormsg = "You picked the wrong studio Fool!" });

            var edit = new CreatePackageViewModel
            {
                id = data.id,
                depoprice = data.depositprice,
                details = data.details,
                price = data.price,
                studioid = data.studioid.Value,
                name = data.name,
                images = data.PackageImages.ToList(),
                ImgName = data.PackageImages.FirstOrDefault().ImageName
            };

            return View("editpackage", edit);
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpPost]
        public async Task<ActionResult> Edit(CreatePackageViewModel data)
        {
            if (ViewBag.StudioID != data.studioid)
                return RedirectToAction("packagehome");

            if (!db.UserStudios.ToList().Any(x => x.userid == UserAuthentication.Identity().id && x.studioid == data.studioid))
                return RedirectToAction("Error500", "Home", new { errormsg = "You picked the wrong studio Fool!" });

            if (ModelState.IsValid)
            {
                try
                {
                    if (data.price < data.depoprice || data.price <= 0 || data.depoprice < 0)
                    {
                        TempData["error"] = "Invalid price setting";
                        data.images = db.Packages.Find(data.id).PackageImages.ToList();
                        return View("editpackage", data);
                    }

                    var edit = db.Packages.First(x => x.id == data.id);
                    edit.depositprice = data.depoprice;
                    edit.details = string.IsNullOrWhiteSpace(data.details) ? null : data.details;
                    edit.name = data.name;
                    edit.price = data.price;
                    edit.studioid = data.studioid;

                    var img = db.PackageImages.Where(x => x.PackageID == data.id);

                    if (!string.IsNullOrWhiteSpace(data.ImgName))
                    {
                        if (img == null || img.FirstOrDefault(x=>x.ImageName.ToLower() == data.ImgName.ToLower()) == null)
                        {
                            AzureBlob BlobManagerObj = new AzureBlob(2);
                            foreach (var item in img)
                            {
                                BlobManagerObj.DeleteBlob(data.studioid.ToString(), String.Format("https://storagephotog2.blob.core.windows.net/studio-data/{0}/{1}", item.Package.studioid, item.ImageName));
                            }

                            db.PackageImages.RemoveRange(img);
                            PackageImage package = new PackageImage { ImageName = data.ImgName };
                            edit.PackageImages.Add(package);
                        }                        
                    }

                    else
                    {
                        AzureBlob BlobManagerObj = new AzureBlob(2);
                        foreach (var item in img)
                        {
                            BlobManagerObj.DeleteBlob(data.studioid.ToString(), String.Format("https://storagephotog2.blob.core.windows.net/studio-data/{0}/{1}", item.Package.studioid, item.ImageName));
                        }
                        db.PackageImages.RemoveRange(img);
                    }


                    db.SaveChanges();

                    await UpdateFirebaseOrder(edit);
                    return RedirectToAction("PackageHome");
                }
                catch (Exception e)
                {
                    return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
                }
            }

            return View("editpackage", data);
        }

        [StudioPermalinkValidate(RoleID = 2)]
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

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var package = db.Packages.FirstOrDefault(x => x.id == id);

                if (ViewBag.StudioID != package.studioid)
                    return RedirectToAction("packagehome");

                if (package.Studio.UserStudios.Any(x => x.userid == UserAuthentication.Identity().id))
                {
                    if (package.status == "Enabled")
                    {
                        package.status = "Disabled";
                    }
                    else
                    {
                        package.status = "Enabled";
                    }
                    db.SaveChanges();
                    await UpdateFirebaseOrder(package);

                    return RedirectToAction("packagehome");
                }
                else
                {
                    return RedirectToAction("Error500", "Home", new { errormsg = "You are not authorized to delete the package Faggot!" });
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
            }
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpGet]
        public ActionResult AddCharge()
        {
            ViewBag.Title = "Create New Charge Preset";
            ViewBag.SubmitButton = "Create";
            return View("ChargePresetForm");
        }

        private void CheckModel(Charge charge)
        {
            if (string.IsNullOrWhiteSpace(charge.Name))
            {
                ModelState.AddModelError("Name", "Charge Name is required");
            }

            else if (charge.Price <= 0 || !charge.Price.HasValue)
            {
                ModelState.AddModelError("Price", "Charge Price cannot be less than 1");
            }
        }


        [StudioPermalinkValidate(RoleID = 1)]
        [HttpPost]
        public ActionResult AddCharge(AddChargePresetViewModel charge)
        {
            ViewBag.Title = "Create New Charge Preset";
            ViewBag.SubmitButton = "Create";
            if (!ModelState.IsValid)
            {
                return View("ChargePresetForm", charge);
            }

            var chargeNow = new Charge();

            chargeNow.StudioID = ViewBag.StudioID;
            chargeNow.Name = charge.Name;
            chargeNow.Price = charge.Price;
            chargeNow.Description = charge.Description;
            chargeNow.Unit = charge.Unit;

            db.Charges.Add(chargeNow);
            db.SaveChanges();
            return RedirectToAction("packagehome");
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpGet]
        public ActionResult EditCharge(int id)
        {
            ViewBag.Title = "Edit Charge Preset";
            ViewBag.SubmitButton = "Save Changes";
            var charge = db.Charges.FirstOrDefault(x => x.id == id);

            return View("ChargePresetForm", charge);
        }

        [StudioPermalinkValidate(RoleID = 1)]
        [HttpPost]
        public ActionResult EditCharge(int id, AddChargePresetViewModel charge)
        {
            ViewBag.Title = "Edit Charge Preset";
            ViewBag.SubmitButton = "Save Changes";
            if (!ModelState.IsValid)
            {
                return View("ChargePresetForm", charge);
            }

            var chargeNow = db.Charges.FirstOrDefault(x => x.id == charge.id);
            chargeNow.Name = charge.Name;
            chargeNow.Price = charge.Price;
            chargeNow.Description = charge.Description;
            chargeNow.Unit = charge.Unit;
            db.SaveChanges();

            return RedirectToAction("packagehome");
        }

        [NonAction]
        private async Task UpdateFirebaseOrder(Package newPackage)
        {
            FirestoreDb firestore = FirestoreDb.Create("photogw2");

            var collection = firestore.Collection("Quotation");
            var snapshot = await collection.GetSnapshotAsync();

            if (snapshot.Count() != 0)
            {
                var docs = snapshot.Documents;

                foreach (var item in docs)
                {
                    var itemConv = item.ConvertTo<QuotationModel>();

                    for (int j = 0; j < itemConv.Packages?.Count; j++)
                    {
                        if (itemConv.Packages[j].Package.Id == newPackage.id)
                        {
                            itemConv.Packages[j].Package.Name = newPackage.name;
                            if (itemConv.Packages[j].OrderStatus.ToLower() != "pending deposit")
                            {
                                itemConv.Packages[j].Package.Price = (float)newPackage.price;
                                itemConv.Packages[j].Package.DepositPrice = (float)newPackage.depositprice;
                                itemConv.Packages[j].Package.Status = newPackage.status;
                            }
                        }
                    }

                    await collection.Document(item.Id).SetAsync(itemConv);
                }
            }
        }
    }
}