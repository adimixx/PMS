using PMS.Models;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult SignIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInViewModel signIn)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                if (UserAuthentication.SignIn(HttpContext,signIn.Email, signIn.Password, signIn.RememberMe))
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid Username / Password");
            }
            return View(signIn);
        }

        public ActionResult SignOut()
        {
            UserAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}