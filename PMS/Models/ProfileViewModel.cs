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
        [DisplayName("Full Name")]
        [Required]
        [RequiredIf("EditID", 1)]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Current Password")]
        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("New Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirm New Password")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNum { get; set; }
        

        [DisplayName("Profile Picture")]
        public HttpPostedFileBase ProfileImage { get; set; }

        public string ProfileImageURI { get; set; }

        [Required]
        public int EditID { get; set; }
    }
}