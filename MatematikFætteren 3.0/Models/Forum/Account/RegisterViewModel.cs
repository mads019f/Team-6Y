using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matematik.Models.Forum.Account
{
    public class RegisterViewModel
    {

        [Required]
        [Display(Name = "Indtast brugernavn her")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Indtast Email her")]
        public string Email { get; set; }
        [Required]

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Matcher ikke overens med Password")]
        [Display(Name = "Bekræft adgangskode")]
        public string ConfirmPassword { get; set; }

    }
}
