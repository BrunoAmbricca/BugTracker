using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using BugTracker.Domain.Common;
using BugTracker.Domain.Entities.Projects;
using BugTracker.Domain.Entities.Users;
using BugTracker.Domain.Entities.Issues;

namespace BugTracker.Persistence.Persistence
{
    public class BugTrackerDbContext : DbContext
    {
        public DbSet<Project>? Projects { get; set; }

        public DbSet<Issue>? Issues { get; set; }

        public DbSet<ApplicationUser>? Users { get; set; }

        public BugTrackerDbContext(DbContextOptions<BugTrackerDbContext> options)
            : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellation = default)
        {
            foreach(var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellation);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BugTrackerDbContext).Assembly);
        }
    }
}
