using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace PMS.Models
{
    public class SignInViewModel
    {
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        public bool validate(ModelStateDictionary model)
        {
            if (model.IsValid)
            {
                Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
                if (!regex.IsMatch(Email))
                {
                    model.AddModelError("Email", "Email is not valid");
                    return false;
                }
                return true;
            }
            return false;
        }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password must be the same")]
        public string ConfirmPassword { get; set; }
    }


    public class RegisterViewModel
    {
        [Required]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password must be the same")]
        public string ConfirmPassword { get; set; }

        public bool validate(ModelStateDictionary model)
        {
            if (model.IsValid)
            {
                Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
                if (!regex.IsMatch(Email))
                {
                    model.AddModelError("Email", "Email is not valid");
                    return false;
                }

                var db = new photogEntities();
                var user = db.Users.FirstOrDefault(x => x.email.ToLower() == Email.ToLower().Trim());

                if (user != null)
                {
                    model.AddModelError("Email", "Email Already Exists");
                    return false;
                }

                return true;
            }
            return false;
        }
    }
}