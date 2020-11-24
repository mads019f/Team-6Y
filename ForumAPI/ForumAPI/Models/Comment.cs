using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedWhen { get; set; }
        public string Author { get; set; }
        public int UserId { get; set; }
        
        public virtual Post Post { get; set; }

    }
}
