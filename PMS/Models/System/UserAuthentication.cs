using Newtonsoft.Json;
using PMS.Models.Database;
using System;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PMS.Models
{
    public class UserAuthentication
    {
        public static bool SignIn(HttpContextBase context, string email, string password, bool rememberMe)
        {
            photogEntities db = new photogEntities();
            try
            {
                var user = db.Users.FirstOrDefault(x => x.email.ToLower() == email && x.password == password);

                if (user != null)
                {
                    var userData = JsonConvert.SerializeObject(user, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                    var authCookie = FormsAuthentication.GetAuthCookie(user.name, rememberMe);
                    var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    var newTicket = new FormsAuthenticationTicket(
                            authTicket.Version,
                            authTicket.Name,
                            authTicket.IssueDate,
                            authTicket.Expiration,
                            authTicket.IsPersistent,
                            userData
                        );

                    authCookie.Value = FormsAuthentication.Encrypt(newTicket);

                    context.Response.Cookies.Set(authCookie);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }       
        }

        public static void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public static User Identity()
        {
            if (HttpContext.Current.User?.Identity?.Name != null && HttpContext.Current.User?.Identity is FormsIdentity identity)
            {
                return JsonConvert.DeserializeObject<User>(identity.Ticket.UserData);
            }

            return null;
        }
    }

    public class UserRoleProvider : RoleProvider
    {
        photogEntities db = new photogEntities();

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            return UserAuthentication.Identity().UserSystemRoles.Select(x => x.SystemRole.name).ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}