using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProjectNet.Data.Entities;
using ProjectNet.Data.Interfaces;

namespace ProjectNet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
           IEnumerable<EntityEntry> modified = ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Modified || x.State == EntityState.Added);
            foreach (EntityEntry item in modified)
            {
                if(item.Entity is IDateTracking changedOrAddedItem)
                {
                    if(item.State == EntityState.Added)
                    {
                        changedOrAddedItem.CreatedDate = DateTime.Now;
                    }
                    else if(item.State == EntityState.Modified)
                    {
                        changedOrAddedItem.LastModifiedDate = DateTime.Now;
                    }
                    
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Lesson>? Lessons { get; set; }
        public DbSet<Category>? Categories { get; set; }
    }
}