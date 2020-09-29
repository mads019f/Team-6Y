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
        [StringLength(60, MinimumLength = 20, ErrorMessage = "Titlen skal være mellem 20 og 60 bostaver")]
        public string Title { get; set; }

        public DateTime Date = DateTime.Now;

        [StringLength(300, MinimumLength = 10, ErrorMessage = "Du skal skrive mellem 10 og 300 bogstaver")]
        public string Description { get; set; }
        public int NewsId { get; set; }
        public string UserId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
