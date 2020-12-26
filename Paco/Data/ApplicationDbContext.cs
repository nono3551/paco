using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Paco.Data.Entities;
using Paco.Data.Identity;
using System;
using System.IO;
using Paco.Data.Entities.Identity;

namespace Paco.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbSet<ManagedSystem> ManagedSystems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is IDbEntity entity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedAt = DateTime.UtcNow;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        entity.UpdatedAt = DateTime.UtcNow;
                    }
                    else if (entry.State == EntityState.Deleted)
                    {
                        entry.State = EntityState.Unchanged;
                        entity.DeletedAt = DateTime.UtcNow;
                    }
                }
                else
                {
                    throw new InvalidDataException("Every database entity must inherit IDbEntity");

                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            SetupQueryFilters(builder);

            base.OnModelCreating(builder);
        }

        private void SetupQueryFilters(ModelBuilder builder)
        {
            builder.Entity<User>().HasQueryFilter(p => p.DeletedAt == null);
            builder.Entity<Role>().HasQueryFilter(p => p.DeletedAt == null);
            builder.Entity<UserClaim>().HasQueryFilter(p => p.DeletedAt == null);
            builder.Entity<UserRole>().HasQueryFilter(p => p.DeletedAt == null);
            builder.Entity<UserLogin>().HasQueryFilter(p => p.DeletedAt == null);
            builder.Entity<UserClaim>().HasQueryFilter(p => p.DeletedAt == null);
            builder.Entity<UserToken>().HasQueryFilter(p => p.DeletedAt == null);
            builder.Entity<ManagedSystem>().HasQueryFilter(p => p.DeletedAt == null);
        }
    }
}
