using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class ProfileViewModel
    {
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Password")]
        [Required]
        public string Password { get; set; }

        [DisplayName("Full Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]

        public string PhoneNum { get; set; }

        [DisplayName("Profile Picture")]
        public HttpPostedFileBase ProfileImage { get; set; }

        public string ProfileImageURI { get; set; }
    }
}