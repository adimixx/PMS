using PMS.Models.Database;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Routing;

namespace PMS.Models
{
    public class StudioPermalinkValidate : ActionFilterAttribute
    {
        public long RoleID { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            photogEntities db = new photogEntities();

            var permalink = (string)filterContext.RouteData.Values["permalink"];
            var checkStudio = db.Studios.FirstOrDefault(x => x.uniquename.ToLower() == permalink.ToLower());

            if (checkStudio == null)
            {
                filterContext.Result = new HttpNotFoundResult();
                return;
            }

            var UserStudio = UserAuthentication.Identity()?.UserStudios.FirstOrDefault(x => x.studioid == checkStudio.id);

            if (RoleID != 0)
            {
                if (UserStudio == null)
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                    return;
                }

                if (RoleID == 1 && UserStudio.studioroleid != RoleID)
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                    return;
                }
            }

            if (UserStudio != null) filterContext.Controller.ViewBag.StudioRoleID = UserStudio.studioroleid;
            filterContext.Controller.ViewBag.StudioID = checkStudio.id;
            filterContext.Controller.ViewBag.StudioUrl = checkStudio.uniquename;
            filterContext.Controller.ViewBag.StudioName = checkStudio.name;
        }
    }
}