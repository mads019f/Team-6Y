using Matematik5_0.Models.WebModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matematik5_0.Models
{
    public class ApplicationUser : IdentityUser
    {
      
        public int ExcerciseRating { get; set; } = 0;
        public int ForumRating { get; set; } = 1000;

        public List<Excercise> SolvedExcercises { get; set; } 
    }
}
