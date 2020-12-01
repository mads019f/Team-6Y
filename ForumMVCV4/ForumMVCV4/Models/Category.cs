using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumMVCV4.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedWhen { get; set; }

        // Navigation Properties
        public IEnumerable<Post> Posts { get; set; }
    }
}
