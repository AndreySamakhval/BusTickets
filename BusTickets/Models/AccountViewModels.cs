using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusTickets.Models
{

        public class ExternalLoginConfirmationViewModel
        {
            [Required]
            [Display(Name = "E-mail")]
            public string Email { get; set; }
        }

        public class ExternalLoginListViewModel
        {
            public string ReturnUrl { get; set; }
        }

       
        public class ForgotViewModel
        {
            [Required]
            [Display(Name = "E-mail")]
            public string Email { get; set; }
        }

        public class LoginViewModel
        {
            [Required]
            [Display(Name = "E-mail")]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Remember me")]
            public bool RememberMe { get; set; }
        }

        public class RegisterViewModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "E-mail")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The value {0} must be at least {2} characters.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm Password")]
            [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
            public string ConfirmPassword { get; set; }
        }
           
        public class ForgotPasswordViewModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "E-mail")]
            public string Email { get; set; }
        }
    }
