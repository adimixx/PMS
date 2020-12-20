using PMS.Models.Database;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace PMS.Models
{
    public class StudioPermalinkValidate : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            photogEntities db = new photogEntities();

            var permalink = (string)filterContext.RouteData.Values["permalink"];

            var checkStudio = db.Studios.FirstOrDefault(x => x.uniquename.ToLower() == permalink.ToLower());

            if (checkStudio == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
               new { action = "Index", controller = "Home" }));
                return;
            }

            filterContext.Controller.ViewBag.StudioID = checkStudio.id;
            filterContext.Controller.ViewBag.StudioUrl = checkStudio.uniquename;
            filterContext.Controller.ViewBag.StudioRoleID = checkStudio.UserStudios.FirstOrDefault().studioroleid;
            filterContext.Controller.TempData["StudioID"] = checkStudio.id;
            filterContext.Controller.TempData["StudioRoleID"] = checkStudio.UserStudios.FirstOrDefault().studioroleid;
        }
    }

    public class StudioAuthorizationRole : AuthorizeAttribute
    {
        public long RoleID { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            //var user = UserAuthentication.Identity()?.id;
            //if (user == null)
            //{
            //    filterContext.Result = new HttpNotFoundResult();
            //    return;
            //}

            //photogEntities db = new photogEntities();
            //var permalink = (string)filterContext.RouteData.Values["permalink"];
            //var checkStudio = db.Studios.FirstOrDefault(x => x.uniquename.ToLower() == permalink.ToLower());
            //var checkRole = db.UserStudios.FirstOrDefault(x => x.userid == user && x.studioid == checkStudio.id);

            var checkRole = filterContext.Controller.TempData["StudioRoleID"];

            if (RoleID != 0 && checkRole == null)
            {
                HandleUnauthorizedRequest(filterContext);
            }

            else if (RoleID == 1 && (int)checkRole != RoleID)
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }
    }

    public class ValidateStudioAPI : AuthorizeAttribute
    {
        public long RoleID { get; set; }
        public static long studioID { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            var checkRole = filterContext.Controller.TempData["StudioID"];

            if (RoleID != 0 && checkRole == null)
            {
                HandleUnauthorizedRequest(filterContext);
                return;
            }

            else if (RoleID == 1 && (long)checkRole != RoleID)
            {
                HandleUnauthorizedRequest(filterContext);
                return;
            }

            studioID = (long)checkRole;
        }
    }
}