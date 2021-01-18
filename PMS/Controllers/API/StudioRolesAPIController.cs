using PMS.Models;
using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Http;

namespace PMS.Controllers.API
{
    public class StudioRolesAPIController : ApiController
    {
        photogEntities db = new photogEntities();

        private int StudioID
        {
            get
            {
                IEnumerable<string> StudioCredential;
                Request.Headers.TryGetValues("StudioCredential", out StudioCredential);
                int.TryParse(StudioCredential.FirstOrDefault(), out int studioID);

                return studioID;
            }
        }

        [HttpGet]
        //[StudioAPIValidate(RoleID = 1)]
        public IHttpActionResult GetRoleList()
        {
            try
            {
                var roles = db.UserStudios.ToList().Where(x => x.studioid == StudioID);

                List<dynamic> data = new List<dynamic>();
                foreach (var item in roles)
                {
                    data.Add(new
                    {
                        item.User.name,
                        item.userid,
                        StudioRole = item.StudioRole.name
                    });
                }

                return Ok(data);
            }

            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        //[StudioAPIValidate(RoleID = 1)]
        public IHttpActionResult GetRole(int id)
        {
            try
            {
                var roles = db.UserStudios.ToList().FirstOrDefault(x => x.studioid == StudioID && x.userid == id);

                return Ok(new
                {
                    roles.User.name,
                    roles.User.email,
                    roles.userid,
                    StudioRole = roles.StudioRole.id,
                    selfUser = (roles.userid == UserAuthentication.Identity().id)
                });
            }

            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        //[StudioAPIValidate(RoleID = 1)]
        public IHttpActionResult SetRoleList(RoleModel role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    photogEntities db = new photogEntities();
                    var user = db.Users.FirstOrDefault(x => x.email.ToLower() == role.Email.ToLower().Trim());
                    if (user == null)
                    {
                        return BadRequest("User email does not exist");
                    }

                    else if(!user.isVerified){
                        return BadRequest("User is not verified.");
                    }

                    if (role.Operation == 1)
                    {
                        var userStudio = user.UserStudios.FirstOrDefault(x => x.studioid == StudioID);
                        if (userStudio == null)
                        {
                            db.UserStudios.Add(new UserStudio { studioid = StudioID, userid = user.id, studioroleid = role.Role });
                        }
                        else if (userStudio.isActive == false)
                        {
                            userStudio.isActive = true;
                        }

                        else
                        {
                            return BadRequest("User already registered with this Studio");
                        }

                        db.SaveChanges();
                        return Ok("User has been added successfully");
                    }

                    else if (role.Operation == 2)
                    {
                        var userStudio = user.UserStudios.FirstOrDefault(x => x.studioid == StudioID);

                        if (userStudio == null)
                        {
                            return BadRequest("User is not registered with this Studio");
                        }

                        userStudio.studioroleid = role.Role;
                        db.SaveChanges();
                        return Ok("User role have been updated");
                    }

                    else if (role.Operation == 3)
                    {
                        var userStudio = user.UserStudios.FirstOrDefault(x => x.studioid == StudioID);

                        if (userStudio == null)
                        {
                            return BadRequest("User is not registered with this Studio");
                        }
                        else if (userStudio.userid == UserAuthentication.Identity().id)
                        {
                            return BadRequest("Cannot delete your own profile from studio!");
                        }
                        else if (db.UserStudios.Where(x=>x.id != userStudio.id && x.studioroleid == 1).Count() <= 0)
                        {
                            return BadRequest("No Admin Detected. Please assign other admin before removing account");
                        }
                        else if (userStudio.JobDateUsers.Count() != 0)
                        {
                            userStudio.isActive = false;
                        }
                        else
                        {
                            db.UserStudios.Remove(userStudio);
                        }
                        
                        db.SaveChanges();
                        return Ok("User role have been deleted");
                    }
                }
                return BadRequest("Invalid Request");
            }

            catch
            {
                return InternalServerError();
            }
           
        }

        public class RoleModel
        {
            [Required]
            public string Email { get; set; }

            //1 = Insert
            //2 = Update
            //3 = Delete
            [Required]
            public int Operation { get; set; }

            [RequiredIf(otherProperty: "Operation", otherPropertyValue: 1)]
            public int Role { get; set; }
        }
    }
}