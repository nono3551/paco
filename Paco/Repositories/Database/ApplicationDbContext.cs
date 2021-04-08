using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Paco.Entities;
using Paco.Entities.Models;
using Paco.Entities.Models.Identity;
using Paco.Entities.Models.Updating;
using Paco.SystemManagement;
using Paco.SystemManagement.Ssh;

namespace Paco.Repositories.Database
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbSet<ManagedSystem> ManagedSystems { get; set; }
        public DbSet<RoleManagedSystemPermissions> RoleManagedSystemPermissions { get; set; }
        public DbSet<LogRecord> LogRecords { get; set; }
        public DbSet<ManagedSystemGroup> ManagedSystemGroups { get; set; }
        public DbSet<ManagedSystemManagedSystemGroup> ManagedSystemManagedSystemGroups { get; set; }
        public DbSet<RoleManagedSystemGroupPermissions> RoleManagedSystemGroupPermissions { get; set; }
        public DbSet<ScheduledAction> ScheduledActions { get; set; }
        public DbSet<QueuedEmail> QueuedEmails { get; set; }
        public DbSet<EmailRecipient> EmailRecipients { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILoggerFactory loggerFactory): base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            SoftDelete();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            SoftDelete();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SoftDelete();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            SoftDelete();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void SoftDelete()
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
                        entity.DeletedAt = DateTime.UtcNow;
                        entry.State = EntityState.Modified;
                    }
                }
                else
                {
                    throw new InvalidDataException("Every database entity must inherit IDbEntity");

                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            SetupQueryFilters(builder);
            SetupNavigationAndKeys(builder);
            SeedDatabase(builder);
        }

        private void SetupNavigationAndKeys(ModelBuilder builder)
        {
            builder.Entity<RoleManagedSystemPermissions>().HasKey(x => new { x.Id, x.RoleId, x.ManagedSystemId });

            builder.Entity<RoleManagedSystemPermissions>()
                .HasOne(a => a.Role)
                .WithMany(b => b.RoleManagedSystemPermissions)
                .HasForeignKey(a => a.RoleId);

            builder.Entity<RoleManagedSystemPermissions>()
                .HasOne(a => a.ManagedSystem)
                .WithMany(b => b.RoleManagedSystemPermissions)
                .HasForeignKey(a => a.ManagedSystemId);

            builder.Entity<ScheduledAction>()
                .HasOne(su => su.ManagedSystem)
                .WithMany(ms => ms.ScheduledActions)
                .HasForeignKey(su => su.ManagedSystemId);
            
            builder.Entity<ScheduledAction>()
                .HasOne(su => su.ScheduledBy)
                .WithMany(ms => ms.ActionsScheduled)
                .HasForeignKey(su => su.ScheduledById);
            
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
                        typeBuilder.HasKey(ur => new { ur.Id, ur.UserId, ur.RoleId });
                    });
            
            builder.Entity<RoleManagedSystemGroupPermissions>().HasKey(x => new { x.Id, x.RoleId, x.ManagedSystemGroupId });

            builder.Entity<RoleManagedSystemGroupPermissions>()
                .HasOne(a => a.Role)
                .WithMany(b => b.RoleManagedSystemGroupPermissions)
                .HasForeignKey(a => a.RoleId);

            builder.Entity<RoleManagedSystemGroupPermissions>()
                .HasOne(a => a.ManagedSystemGroup)
                .WithMany(b => b.RoleManagedSystemGroupPermissions)
                .HasForeignKey(a => a.ManagedSystemGroupId);
            
            builder.Entity<ManagedSystem>()
                .HasMany(u => u.ManagedSystemGroups)
                .WithMany(r => r.ManagedSystems)
                .UsingEntity<ManagedSystemManagedSystemGroup>(
                    typeBuilder => typeBuilder
                        .HasOne(ur => ur.ManagedSystemGroup)
                        .WithMany(t => t.ManagedSystemManagedSystemGroups)
                        .HasForeignKey(ur => ur.ManagedSystemGroupId),
                    typeBuilder => typeBuilder
                        .HasOne(ur => ur.ManagedSystem)
                        .WithMany(p => p.ManagedSystemManagedSystemGroups)
                        .HasForeignKey(pt => pt.ManagedSystemId),
                    typeBuilder =>
                    {
                        typeBuilder.HasKey(ur => new { ur.Id, ur.ManagedSystemId, ur.ManagedSystemGroupId });
                    });

            builder.Entity<QueuedEmail>()
                .HasMany(r => r.Recipients)
                .WithMany(r => r.QueuedEmails)
                .UsingEntity<EmailRecipient>(
                    typeBuilder => typeBuilder
                        .HasOne(ur => ur.Recipient)
                        .WithMany(p => p.EmailRecipientUser)
                        .HasForeignKey(pt => pt.UserId),
                    typeBuilder => typeBuilder
                        .HasOne(ur => ur.QueuedEmail)
                        .WithMany(t => t.EmailRecipients)
                        .HasForeignKey(ur => ur.QueuedEmailId),
                    typeBuilder =>
                    {
                        typeBuilder.HasKey(ur => new { ur.Id });
                    });
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
            builder.Entity<RoleManagedSystemPermissions>().HasQueryFilter(p => p.DeletedAt == null);
            builder.Entity<ManagedSystemGroup>().HasQueryFilter(p => p.DeletedAt == null);
            builder.Entity<ManagedSystemManagedSystemGroup>().HasQueryFilter(p => p.DeletedAt == null);
            builder.Entity<RoleManagedSystemGroupPermissions>().HasQueryFilter(p => p.DeletedAt == null);
            builder.Entity<ScheduledAction>().HasQueryFilter(p => p.DeletedAt == null);
            builder.Entity<QueuedEmail>().HasQueryFilter(p => p.DeletedAt == null);
            builder.Entity<EmailRecipient>().HasQueryFilter(p => p.DeletedAt == null);
        }

        private void SeedDatabase(ModelBuilder builder)
        {
            var email = "michal.zahradnik@backbone.sk";
            var emailUpper = email.ToUpper();
            
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = email,
                Email = email,
                NormalizedEmail = emailUpper,
                NormalizedUserName = emailUpper,
                PasswordHash = "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==",
                SecurityStamp = "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU",
                ConcurrencyStamp = "34acbb54-9ae3-4742-af3c-89de44e306e0",
                EmailConfirmed = true,
                LockoutEnabled = true
            };
            builder.Entity<User>().HasData(user);

            
            var role = new Role {Id = Guid.NewGuid(), Name = "Administrator", NormalizedName = "ADMINISTRATOR"};
            builder.Entity<Role>().HasData(role);

            builder.Entity<UserRole>().HasData(new UserRole
            {
                Id = Guid.NewGuid(),
                RoleId = role.Id,
                UserId = user.Id
            });
        }
    }
}
