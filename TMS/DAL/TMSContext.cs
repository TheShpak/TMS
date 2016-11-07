using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TMS.DAL
{
    public class TMSContext : DbContext
    {
        public TMSContext() : base("TMSContext")
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

