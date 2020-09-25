using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matematik.Models.Forum
{
    public class Comment
    {
        public int? PostId { get; set; }
        public int CommentId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        public Post Post { get; set; }


    }
}
