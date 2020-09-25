using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matematik.Models.Forum
{
    public class ForumCategory
    {
        public string Title { get; set; }
        public int ForumCategoryId { get; set; }
        public Forum Forum { get; set; }
        public int? ForumId { get; set; }
    }
}
