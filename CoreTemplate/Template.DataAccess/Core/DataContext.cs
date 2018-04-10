using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Common.Entities;
using Microsoft.Extensions.Configuration;

namespace Template.DataAccess.Core
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Template;Integrated Security=False; User Id=sa; Password=123; Timeout=500000;");
            optionsBuilder.UseSqlServer("Data Source = devdb01; Initial Catalog = Bicasemgmt; User ID = biweb; Password = biweb; MultipleActiveResultSets = True; App = NGTotalAccessApi");

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual void Save()
        {
            base.SaveChanges();
        }

        #region Entities representing Database Objects
        public DbSet<Client> Client { get; set; }
        public DbSet<Alert> Alert { get; set; }

        //public DbSet<JobTask> JobTask { get; set; }
        //public DbSet<JobWorker> JobWorker { get; set; }
        //public DbSet<Property> Property { get; set; }
        //public DbSet<ServiceRequest> ServiceRequest { get; set; }
        //public DbSet<Status> Status { get; set; }
        //public DbSet<Tenant> Tenant { get; set; }
        #endregion
    }
}
