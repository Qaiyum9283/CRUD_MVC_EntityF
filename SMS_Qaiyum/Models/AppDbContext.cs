using PM_Qaiyum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PM_Qaiyum.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") 
        { 
        }

        public DbSet<Product> Products { get; set; }

    }
}