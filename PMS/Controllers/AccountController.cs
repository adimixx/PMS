using PMS.Models;
using PMS.Models.Database;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
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
                string error;
                if (UserAuthentication.SignIn(HttpContext, signIn.Email, signIn.Password, signIn.RememberMe, out error))
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", error);
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

                var veriKey = (new Backbone()).Random(8);

                User user = new User { email = registerViewModel.Email.Trim().ToLower(), password = registerViewModel.Password, isVerified = false, verifiedKey = veriKey, name = registerViewModel.Email };
                user.UserSystemRoles.Add(new UserSystemRole { systemroleid = 2 });

                db.Users.Add(user);
                db.SaveChanges();

                string url = string.Format("https://{0}/Account/Validate?key={1}", Request.Url.Authority, veriKey);
                string emailContent = String.Format("Click Here to verify Account : {0}", url);

                var client = new SmtpClient("smtp.titan.email", 587)
                {
                    Credentials = new NetworkCredential("hello@photog123.online", "RareMaHZUU")
                };
                client.Send("hello@photog123.online", user.email, "Verify your Account", emailContent);

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
            else if (checkItem.isVerified && checkItem.isForgotPassword)
            {
                checkItem.isForgotPassword = false;
                checkItem.emailTemp = null;
                checkItem.verifiedKey = null;
                TempData["ForgotPasswordEmail"] = checkItem.email;
                return RedirectToAction("ResetPassword", "Account");
            }
            else if (checkItem.isVerified && string.IsNullOrWhiteSpace(checkItem.emailTemp))
            {
                return new HttpUnauthorizedResult("Expired Link");
            }
            if (!string.IsNullOrWhiteSpace(checkItem.emailTemp))
            {
                var check = db.Users.FirstOrDefault(x => x.email.ToLower() == checkItem.emailTemp.ToLower());

                if (check != null)
                {
                    return new HttpUnauthorizedResult("Expired Link");
                }

                checkItem.email = checkItem.emailTemp;
                checkItem.emailTemp = null;
            }

            else
            {
                checkItem.isVerified = true;
            }

            checkItem.verifiedKey = null;
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

        [HttpGet]
        [Authorize]
        public ActionResult Edit()
        {
            var user = UserAuthentication.Identity();
            ProfileViewModel profile = new ProfileViewModel { Email = user.email, Name = user.name, PhoneNum = user.phonenumber };
            return View(profile);
        }            

        [HttpPost]
        [Authorize]
        public ActionResult Edit(ProfileViewModel profile)
        {
            photogEntities db = new photogEntities();
            var userID = UserAuthentication.Identity().id;
            var user = db.Users.FirstOrDefault(x => x.id == userID);

            if (ModelState.IsValid)
            {               
                if (profile.EditID == 1)
                {
                    user.name = profile.Name;
                }
                else if (profile.EditID == 2)
                {
                    user.phonenumber = profile.PhoneNum;
                }

                else if (profile.EditID == 3)
                {
                    if (user.email.ToLower() == profile.Email.ToLower())
                    {
                        ModelState.AddModelError("Email", "Email is same with existing email");
                    }

                    else if (db.Users.FirstOrDefault(x=>x.id != user.id && x.email.ToLower() == profile.Email.ToLower()) != null)
                    {
                        ModelState.AddModelError("Email", "Email already exists");
                    }

                    if (!ModelState.IsValid)
                    {
                        profile = new ProfileViewModel { Email = profile.Email, Name = user.name, PhoneNum = user.phonenumber };
                        return View(profile);
                    }

                    var veriKey = (new Backbone()).Random(8);
                    string url = string.Format("https://{0}/Account/Validate?key={1}", Request.Url.Authority, veriKey);
                    string emailContent = String.Format("Click Here to verify your new Email : {0}", url);

                    var client = new SmtpClient("smtp.titan.email", 587)
                    {
                        Credentials = new NetworkCredential("hello@photog123.online", "RareMaHZUU")
                    };
                    client.Send("hello@photog123.online", profile.Email, "Verify your new Email", emailContent);

                    user.emailTemp = profile.Email;
                    user.verifiedKey = veriKey;

                    TempData["Email"] = "An email has been sent to " + profile.Email + ", Please check your inbox to validate your email address change";
                }

                else
                {
                    if (profile.OldPassword != user.password)
                    {
                        ModelState.AddModelError("OldPassword", "Invalid old password");
                    }
                    else if (profile.NewPassword != profile.ConfirmPassword)
                    {
                        ModelState.AddModelError("NewPassword", "New Password does not match");
                    }
                    if (!ModelState.IsValid)
                    {
                        profile = new ProfileViewModel { Email = user.email, Name = user.name, PhoneNum = user.phonenumber };
                        return View(profile);
                    }

                    user.password = profile.NewPassword;
                }

                TempData["SuccessMessage"] = "Changes has been saved successfully";

                db.SaveChanges();
                UserAuthentication.UpdateClaim();
                return RedirectToAction("Edit", "Account");
            }

            profile = new ProfileViewModel { Email = user.email, Name = user.name, PhoneNum = user.phonenumber };           
            return View(profile);
        }

        [HttpGet]
        [AnonymousOnly]
        public ActionResult ForgotPassword()
        {
            return View("ForgotPasswordMain");
        }

        [HttpPost]
        [AnonymousOnly]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordViewModel forgot)
        { 
            if (ModelState.IsValid && forgot.validate(ModelState))
            {
                photogEntities db = new photogEntities();
                var users = db.Users.FirstOrDefault(x => x.email.ToLower() == forgot.Email.ToLower());

                if (users != null)
                {
                    users.isForgotPassword = true;
                    users.verifiedKey = (new Backbone()).Random(8);
                    db.SaveChanges();

                    string url = string.Format("https://{0}/Account/Validate?key={1}", Request.Url.Authority, users.verifiedKey);
                    string emailContent = String.Format("Click Here to reset your password : {0}", url);

                    var client = new SmtpClient("smtp.titan.email", 587)
                    {
                        Credentials = new NetworkCredential("hello@photog123.online", "RareMaHZUU")
                    };
                    client.Send("hello@photog123.online", forgot.Email , "Verify your Account", emailContent);
                }

                ViewBag.Email = forgot.Email.ToLower();
                return View("ValidateEmail");
            }
            return View("ForgotPasswordMain");
        }

        [HttpGet]
        [AnonymousOnly]
        public ActionResult ResetPassword()
        {
            if (TempData["ForgotPasswordEmail"] != null)
            {
                ResetPasswordViewModel reset = new ResetPasswordViewModel();
                reset.Email = (string)TempData["ForgotPasswordEmail"];

                TempData.Keep("ForgotPasswordEmail");
                return View(reset);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AnonymousOnly]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordViewModel forgot)
        {
            if (TempData["ForgotPasswordEmail"] != null && !string.IsNullOrWhiteSpace(forgot.Email))
            {
                if (ModelState.IsValid)
                {
                    photogEntities db = new photogEntities();
                    var users = db.Users.FirstOrDefault(x => x.email.ToLower() == forgot.Email.ToLower());

                    if (users != null)
                    {
                        users.password = forgot.Password;
                        db.SaveChanges();
                        TempData["ResetPasswordSuccess"] = "1";
                        return RedirectToAction("SignIn", "Account");
                    }
                }
                else
                {
                    TempData.Keep("ForgotPasswordEmail");
                    return View(forgot);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}