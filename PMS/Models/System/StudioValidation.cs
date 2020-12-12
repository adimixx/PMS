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
            }
        }
    }

    public class StudioAuthorizationRole : AuthorizeAttribute
    {
        public long RoleID { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);


            var user = UserAuthentication.Identity()?.id;
            if (user == null)
            {
                filterContext.Result = new HttpNotFoundResult();
                return;
            }

            photogEntities db = new photogEntities();
            var permalink = (string)filterContext.RouteData.Values["permalink"];
            var checkStudio = db.Studios.FirstOrDefault(x => x.uniquename.ToLower() == permalink.ToLower());
            var checkRole = db.UserStudios.FirstOrDefault(x => x.userid == user && x.studioid == checkStudio.id);

            if (RoleID != 0 && checkRole == null)
            {
                HandleUnauthorizedRequest(filterContext);
            }

            else if (RoleID == 1 && checkRole.id != RoleID)
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}