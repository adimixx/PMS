using PMS.Models;
using PMS.Models.Database;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class AccountController : Controller
    {

        [AnonymousOnly]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [AnonymousOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInViewModel signIn)
        {
            if (ModelState.IsValid)
            {
                if (UserAuthentication.SignIn(HttpContext, signIn.Email, signIn.Password, signIn.RememberMe))
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid Username / Password");
            }
            return View(signIn);

        }

        [AnonymousOnly]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AnonymousOnly]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid && registerViewModel.validate(ModelState))
            {
                var db = new photogEntities();

                var veriKey = Backbone.Random(8);

                User user = new User { email = registerViewModel.Email.Trim().ToLower(), password = registerViewModel.Password, isVerified = false, verifiedKey = veriKey, name = registerViewModel.Email };
                user.UserSystemRoles.Add(new UserSystemRole { systemroleid = 2 });

                db.Users.Add(user);
                db.SaveChanges();

                ViewBag.Email = registerViewModel.Email;
                return View("ValidateEmail");
            }
            return View(registerViewModel);
        }

        [HttpGet]
        public ActionResult Validate(string key)
        {
            var db = new photogEntities();

            var checkItem = db.Users.FirstOrDefault(x => x.verifiedKey.ToLower() == key.ToLower());

            if (checkItem == null)
            {
                return new HttpUnauthorizedResult("Invalid Link");
            }

            else if (checkItem.isVerified)
            {
                return new HttpUnauthorizedResult("Expired Link");
            }

            checkItem.isVerified = true;
            db.SaveChanges();
            TempData["isVerified"] = "1";

            return RedirectToAction("SignIn", "Account");
        }

        [Authorize]
        public ActionResult SignOut()
        {
            UserAuthentication.SignOut(HttpContext);
            return RedirectToAction("Index", "Home");
        }
       
    }
}