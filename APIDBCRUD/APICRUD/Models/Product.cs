using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICRUD.Models
{
    public class Product
    {

        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Mellem 20 og 40 tegn")]
        public string Name { get; set; }
        
        [Required]
        [Range(0,1000)]
        public int Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
        
        
        public DateTime DatetimeUS { get; set; }


    }
}
