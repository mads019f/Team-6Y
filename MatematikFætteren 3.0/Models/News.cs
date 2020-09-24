using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matematik.Models
{
    public class News
    {
        [Required]
        [StringLength(20,MinimumLength = 60, ErrorMessage ="Titlen skal være mellem 20 og 60 bostaver")]
        public string Title { get; set; }

        public DateTime Date = DateTime.Now;

        [StringLength(300, MinimumLength =10, ErrorMessage ="Du skal skrive mellem 10 og 300 bogstaver")]
        public string Body { get; set; }
    }
}
