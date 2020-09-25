using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatematikFætteren_3._0.Models
{
    public class ApplicationUser : IdentityUser
    {

        public int ExcerciseRating { get; set; } = 0;
        public int ForumRating { get; set; } = 1000;    
        
    }
}
