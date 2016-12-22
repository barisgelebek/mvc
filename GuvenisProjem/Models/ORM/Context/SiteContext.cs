using GuvenisProjem.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GuvenisProjem.Models.ORM.Context
{
    public class SiteContext : DbContext
    {
        public SiteContext()
        {
            Database.Connection.ConnectionString = "Server=.;Database=DbGuvenis; Trusted_Connection=True;";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<AdminUser> AdminUsers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<SiteMenu> SiteMenus { get; set; }

        public DbSet<ProjectImage> ProjectImages { get; set; }


    }
}