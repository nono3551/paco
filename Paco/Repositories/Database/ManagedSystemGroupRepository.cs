using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Paco.Entities.Models;
using Paco.Entities.Models.Identity;

namespace Paco.Repositories.Database
{
    public static class ManagedSystemGroupRepository
    {
        public static List<ManagedSystemGroup> GetManagedSystemsForTermWithRolePermissionsForRole(this DbSet<ManagedSystemGroup> groups, Role role, string term, int limit = 15)
        {
            return groups.Where(x => x.Name.Contains(term))
                .Include(x => x.RoleManagedSystemGroupPermissions.Where(y => y.Role.Id == role.Id))
                .OrderBy(x => x.Name)
                .Take(limit)
                .ToList();
        }
        
        public static List<ManagedSystemGroup> GetManagedSystemsWithRolePermissionsForRole(this DbSet<ManagedSystemGroup> systems, Role role)
        {
            return systems.Include(x => x.RoleManagedSystemGroupPermissions.Where(y => y.Role == role))
                .Where(x => x.RoleManagedSystemGroupPermissions.Any(y => y.Role == role))
                .OrderBy(x => x.Name)
                .ToList();
        }
    }
}