using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matematik.Models.Forum.Account
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Indtast brugernavn her")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Husk mig")]
        public bool RememberMe { get; set; }

    }
}
