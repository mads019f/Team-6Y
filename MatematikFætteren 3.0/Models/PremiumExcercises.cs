using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matematik.Models
{
    public class PremiumExcercises
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyEmail { get; set; }
        [Required]
        public string Answer { get; set; }
        
    }
}
