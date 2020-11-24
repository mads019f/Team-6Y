using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumMVC.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime CreatedWhen { get; set; }
        public string Author { get; set; }
        public int UserID { get; set; }
        public int PostID { get; set; }

        //Navigation Property
        public virtual Post Post { get; set; }
    }
}
