using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Paco.Data.Entities;

namespace Paco.Data.DatabaseRepository
{
    public static class RoleSystemPermissionRepository
    {
        public static List<RoleSystemPermission> GetPermissionsWithSystemsForRole(this DbSet<RoleSystemPermission> roleSystemPermissions, Guid roleId)
        {
            return roleSystemPermissions.Where(r => r.Role.Id == roleId)
                .Include(s => s.ManagedSystem)
                .ToList();
        }
    }
}