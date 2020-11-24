using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedWhen { get; set; }

        // Navigation Properties
        public virtual IEnumerable<Post> Posts { get; set; }
    }
}
