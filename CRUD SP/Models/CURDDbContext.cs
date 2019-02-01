using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD_SP.Models
{
    public class CURDDbContext : DbContext
    {
        public CURDDbContext()
            : base("CURDDbContext")
        {
        }

        public static CURDDbContext Create()
        {
            return new CURDDbContext();
        }

        public DbSet<TrainingProduct> Products { get; set; }


    }
}