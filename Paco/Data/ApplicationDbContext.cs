using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Paco.Data.Entities;
using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Paco.Data.Entities.Identity;
using Paco.SystemManagement;
using Paco.SystemManagement.Ssh;

namespace Paco.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        private readonly ILoggerFactory _loggerFactory;


        public DbSet<ManagedSystem> ManagedSystems { get; set; }
        public DbSet<RoleSystemPermissions> RoleSystemPermissions { get; set; }
        public DbSet<LogRecord> LogRecords { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILoggerFactory loggerFactory): base(options)
        {
            _loggerFactory = loggerFactory;
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
                        entity.UpdatedAt = DateTime.UtcNow;
                        entity.IsDeleted = true;;
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

        private void SetupRoleSystemPermissionsMapping(ModelBuilder builder)
        {
            builder.Entity<RoleSystemPermissions>().HasKey(x => new { x.Id, x.RoleId, SystemId = x.ManagedSystemId });

            builder.Entity<RoleSystemPermissions>()
                .HasOne(a => a.Role)
                .WithMany(b => b.SystemsPermissions)
                .HasForeignKey(a => a.RoleId);

            builder.Entity<RoleSystemPermissions>()
                .HasOne(a => a.ManagedSystem)
                .WithMany(b => b.RolesPermissions)
                .HasForeignKey(a => a.ManagedSystemId);

            builder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<UserRole>(
                    typeBuilder => typeBuilder
                        .HasOne(ur => ur.Role)
                        .WithMany(p => p.UserRoles)
                        .HasForeignKey(pt => pt.RoleId),
                    typeBuilder => typeBuilder
                        .HasOne(ur => ur.User)
                        .WithMany(t => t.UserRoles)
                        .HasForeignKey(ur => ur.UserId),
                    typeBuilder =>
                    {
                        typeBuilder.HasKey(ur => new { ur.UserId, ur.RoleId });
                    });
        }

        private void SetupQueryFilters(ModelBuilder builder)
        {
            builder.Entity<User>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Role>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<UserClaim>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<UserRole>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<UserLogin>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<UserClaim>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<UserToken>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<ManagedSystem>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<LogRecord>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<RoleSystemPermissions>().HasQueryFilter(p => !p.IsDeleted);
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

            var system1 = new ManagedSystem()
            {
                Id = Guid.NewGuid(),
                Name = "PermNone",
                Hostname = "none.test.test",
                Distribution = Distribution.FreeBsd,
                Login = "test",
                Password = "test",
                SshPrivateKey = null,
                SystemFingerprint = Fingerprint.FingerprintPlaceholder
            };

            var system2 = new ManagedSystem()
            {
                Id = Guid.NewGuid(),
                Name = "PermMultiple",
                Hostname = "multiple.test.test",
                Distribution = Distribution.FreeBsd,
                Login = "test",
                Password = "test",
                SshPrivateKey = null,
                SystemFingerprint = Fingerprint.FingerprintPlaceholder
            };
            builder.Entity<ManagedSystem>().HasData(system1);
            builder.Entity<ManagedSystem>().HasData(system2);

            var role = new Role {Id = Guid.NewGuid(), Name = "Administrator"};
            builder.Entity<Role>().HasData(role);

            builder.Entity<UserRole>().HasData(new UserRole
            {
                RoleId = role.Id,
                UserId = user.Id
            });

            builder.Entity<RoleSystemPermissions>().HasData(new RoleSystemPermissions()
            {
                Id = Guid.NewGuid(),
                RoleId = role.Id,
                ManagedSystemId = system1.Id,
                Permissions = Permissions.None
            }, new RoleSystemPermissions()
            {
                Id = Guid.NewGuid(),
                RoleId = role.Id,
                ManagedSystemId = system2.Id,
                Permissions = Permissions.Read | Permissions.Execute | Permissions.Write
            });
        }
    }
}
