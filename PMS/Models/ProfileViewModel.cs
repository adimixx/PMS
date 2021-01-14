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
        [RequiredIf("EditID", 1, ErrorMessage ="Name is Required")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        [RequiredIf("EditID", 3, ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Current Password")]
        [RequiredIf("EditID", 4, ErrorMessage = "Please fill in Old Password")]
        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("New Password")]
        [RequiredIf("EditID", 4, ErrorMessage = "Please fill in New Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirm New Password")]
        [RequiredIf("EditID", 4, ErrorMessage = "Please fill in New Password")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RequiredIf("EditID", 2, ErrorMessage = "Please fill in Phone Number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong Phone Number")]
        public string PhoneNum { get; set; }
        

        [DisplayName("Profile Picture")]
        public HttpPostedFileBase ProfileImage { get; set; }

        public string ProfileImageURI { get; set; }

        [Required]
        public int EditID { get; set; }
    }
}