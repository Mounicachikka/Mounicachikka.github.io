using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaazApplication.Models
{
    public class AdminModel
    {
        [Required(ErrorMessage = "UserId is required")]
        [Display(Name =  "Login ID")]
        public string Loginid { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set;  }
        [Display(Name = " Remember me?")]
        public bool Rememberme { get; set; }
    }

   
    public class Login
    {
        public static bool HasLogin = false;
    }
   public class sendemail
    {
        public string Email { get; set; }
    }
}