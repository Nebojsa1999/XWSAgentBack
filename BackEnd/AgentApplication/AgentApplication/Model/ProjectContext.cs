using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AgentApplication.Model
{
    public class ProjectContext : DbContext
    {
        public static ProjectConfiguration Configuration;

        public ProjectContext(DbContextOptions<ProjectContext> options, ProjectConfiguration configuration) : base(options)
        {
            if (configuration != null)
            {
                Configuration = configuration;
            }
        }

        public ProjectContext()
        {
        }

        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entires = ChangeTracker.
                Entries().
                Where(e => e.Entity is Entity &&
                (e.State == EntityState.Added
                || e.State == EntityState.Modified));

            foreach (EntityEntry entityEntry in entires)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((Entity)entityEntry.Entity).Deleted = false;


                }
            }

            return base.SaveChanges();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Reaction> Reactions { get; set; }

        public DbSet<ApiKey> ApiKeys { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }


            //optionsBuilder.UseSqlServer("Server=mssql;Database=usersAgent;User Id=sa;Password=Your_password123;");
            optionsBuilder.UseSqlServer("data source=localhost; Initial Catalog=agentXWS;Integrated Security=True;");

        }
    }
}
