using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Paco.Data.Entities;

namespace Paco.Data.DatabaseRepository
{
    public static class RoleSystemPermissionsRepository
    {
        public static List<RoleSystemPermissions> GetPermissionsWithSystemsForRole(this DbSet<RoleSystemPermissions> roleSystemPermissions, Guid roleId)
        {
            return roleSystemPermissions.Where(r => r.Role.Id == roleId)
                .Include(s => s.ManagedSystem)
                .ToList();
        }
    }
}