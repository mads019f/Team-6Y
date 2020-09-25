using Matematik.Models.Forum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matematik.Models
{
    public class Post
    {
        public string Title { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public ForumCategory ForumCategory { get; set; }
        public int PostId { get; set; }
        

    
    }
}
