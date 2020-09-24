using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matematik.Models
{
    public class Post
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }


        public Post(string title, string author, DateTime dt, string body)
        {
            Title = title;
            Author = author;
            Date = dt;
            Body = body;
        }
    }
}
