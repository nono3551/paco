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
    }
}