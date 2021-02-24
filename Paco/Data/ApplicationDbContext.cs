using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Paco.Data.Entities;
using System;
using System.IO;
using Paco.Data.Entities.Identity;
using Paco.SystemManagement;
using Paco.SystemManagement.Ssh;

namespace Paco.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbSet<ManagedSystem> ManagedSystems { get; set; }
        public DbSet<RoleSystemPermission> RoleSystemPermissions { get; set; }
        public DbSet<LogRecord> LogRecords { get; set; }

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
            SetupRoleSystemPermissionsMapping(builder);
            SeedDatabase(builder);
            base.OnModelCreating(builder);
        }

        private void SeedDatabase(ModelBuilder builder)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = "asd@ads.asd",
                Email = "asd@ads.asd",
                NormalizedEmail = "ASD@ASD.ASD",
                NormalizedUserName = "ASD@ASD.ASD",
                PasswordHash = "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==",
                SecurityStamp = "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU",
                ConcurrencyStamp = "34acbb54-9ae3-4742-af3c-89de44e306e0",
                EmailConfirmed = true,
                LockoutEnabled = true
            };
            builder.Entity<User>().HasData(user);

            var system = new ManagedSystem()
            {
                Id = Guid.NewGuid(),
                Name = "test",
                Hostname = "test.test.test",
                Distribution = Distribution.FreeBsd,
                Login = "test",
                Password = "test",
                SshPrivateKey = null,
                SystemFingerprint = Fingerprint.FingerprintPlaceholder
            };
            builder.Entity<ManagedSystem>().HasData(system);

            var role = new Role {Id = Guid.NewGuid(), Name = "Administrator"};
            builder.Entity<Role>().HasData(role);

            builder.Entity<UserRole>().HasData(new UserRole
            {
                RoleId = role.Id,
                UserId = user.Id
            });

            builder.Entity<RoleSystemPermission>().HasData(new RoleSystemPermission()
            {
                RoleId = role.Id,
                ManagedSystemId = system.Id
            });
        }

        private void SetupRoleSystemPermissionsMapping(ModelBuilder builder)
        {
            builder.Entity<RoleSystemPermission>().HasKey(x => new { x.RoleId, SystemId = x.ManagedSystemId });

            builder.Entity<RoleSystemPermission>()
                .HasOne(a => a.Role)
                .WithMany(b => b.SystemsPermissions)
                .HasForeignKey(a => a.RoleId);

            builder.Entity<RoleSystemPermission>()
                .HasOne(a => a.ManagedSystem)
                .WithMany(b => b.RolesPermissions)
                .HasForeignKey(a => a.ManagedSystemId);
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
            builder.Entity<LogRecord>().HasQueryFilter(p => p.DeletedAt == null);
            builder.Entity<RoleSystemPermission>().HasQueryFilter(p => p.DeletedAt == null);
        }
    }
}
