using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Paco.Data.Entities;
using Paco.Data.Entities.Identity;

namespace Paco.Data.DatabaseRepository
{
    public static class ManagedSystemRepository
    {
        public static List<ManagedSystem> GetSystemsForUser(this DbSet<ManagedSystem> systems, User user)
        {
            return systems.Where(
                    s => s.RolesPermissions.Any(p => p.Permissions > Permissions.None && p.Role.Users.Contains(user)))
                .Include(s => s.RolesPermissions).ToList();
        }
        
        public static List<ManagedSystem> GetSystemsForTermWithRolePermissionsForRole(this DbSet<ManagedSystem> systems, Role role, string term, int limit = 15)
        {
            var asd = systems.Where(x => x.Name.Contains(term) || x.Hostname.Contains(term))
                .Include(x => x.RolesPermissions.Where(y => y.Role.Id == role.Id))
                .OrderBy(x => x.Name)
                .Take(limit)
                .ToList();

            return asd;
        }
        
        public static List<ManagedSystem> GetSystemsWithRolePermissionsForRole(this DbSet<ManagedSystem> systems, Role role)
        {
            return systems.Include(x => x.RolesPermissions.Where(y => y.Role == role))
                .Where(x => x.RolesPermissions.Any(y => y.Role == role))
                .OrderBy(x => x.Name)
                .ToList();
        }
    }
}