using MatematikFætteren_3._0.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatematikFætteren_3._0.ViewModels
{
    public class UserViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public List<IdentityUserRole<string>> UserRoles { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
