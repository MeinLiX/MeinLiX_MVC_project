using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MeinLiX.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "You need to fill the field")]
        [Display(Name="Email")]
        [DataType(DataType.EmailAddress)]
        
        public string Email { get; set; }

        [Required(ErrorMessage = "You need to fill the field")]
        [Display(Name = "Year of born")]
        public int Year { get; set; }

        [Required(ErrorMessage = "You need to fill the field")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "You need to fill the field")]
        [Compare("Password",ErrorMessage = "Passwords do not match")]
        [Display(Name = "Password confirmation")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

    }
}
