using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matematik.Models
{
    public class User
    {
        
        public string Email { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }


        public User(string email, string username, string name, string password)
        {
            Email = email;
            Username = username;
            Name = name;
            Password = password;

        }

    }
}
 