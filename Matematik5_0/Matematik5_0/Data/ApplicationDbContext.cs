using Matematik5_0.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matematik5_0.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext ( DbContextOptions<ApplicationDbContext> options )
            : base(options)
        {
            Database.Migrate();
        }
    }
}
