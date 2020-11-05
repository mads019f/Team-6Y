using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class News
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int NewsId { get; set; }
        public string UserId { get; set; }
        public virtual User user { get; set; }
    }
}
