using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Paco.Data.Entities;
using Paco.Data.Entities.Identity;

namespace Paco.DatabaseRepositories
{
    public static class ManagedSystemRepository
    {
        public static List<ManagedSystem> GetManagedSystemsForUser(this DbSet<ManagedSystem> systems, User user)
        {
            return systems.Where(s => s.RoleManagedSystemPermissions.Any(p => p.Permissions > Permissions.None && p.Role.Users.Contains(user)))
                .Include(s => s.RoleManagedSystemPermissions.Where(rp => rp.Role.Users.Contains(user))).ToList();
        }
        
        public static List<ManagedSystem> GetManagedSystemsForTermWithRolePermissionsForRole(this DbSet<ManagedSystem> systems, Role role, string term, int limit = 15)
        {
            var asd = systems.Where(x => x.Name.Contains(term) || x.Hostname.Contains(term))
                .Include(x => x.RoleManagedSystemPermissions.Where(y => y.Role.Id == role.Id))
                .OrderBy(x => x.Name)
                .Take(limit)
                .ToList();

            return asd;
        }
        
        public static List<ManagedSystem> GetManagedSystemsWithRolePermissionsForRole(this DbSet<ManagedSystem> systems, Role role)
        {
            return systems.Include(x => x.RoleManagedSystemPermissions.Where(y => y.Role == role))
                .Where(x => x.RoleManagedSystemPermissions.Any(y => y.Role == role))
                .OrderBy(x => x.Name)
                .ToList();
        }
    }
}