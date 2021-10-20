using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace E_Commerce_WebApp.FormDataModels
{
    public class CustomerRegisterFormDataModel
    {
        public bool IsAdmin { get; set; }
        public CustomerRegisterFormDataModel()
        {
            this.IsAdmin = false;
        }


        [Required]
        [StringLength(50, ErrorMessage = "{0} is required")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150, ErrorMessage = "{0} is required")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(200, ErrorMessage = "{0} is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} is not valid")]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }

    public class AdminRegisterFormDataModel
    {
        public bool IsAdmin { get; set; }
        public AdminRegisterFormDataModel()
        {
            this.IsAdmin = true;
        }

        [Required(ErrorMessage = "{0} is required")]
        [EmailAddress]
        [StringLength(150, ErrorMessage = "{0} is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} is not valid")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} is not valid")]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
    public class UserLoginFormDataModel
    {

        [Required( ErrorMessage = "{0} is required")]
        [EmailAddress]
        [StringLength(150, ErrorMessage = "{0} is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength =6,ErrorMessage = "{0} is not valid")]
        public string Password { get; set; }

    }
}