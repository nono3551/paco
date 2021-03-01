using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Paco.Data.Entities;
using Paco.Data.Entities.Identity;

namespace Paco.Data.DatabaseRepository
{
    public static class UserRepository
    {
        public static List<User> GetUsersForTermUserRolesForRole(this DbSet<User> users, Role role, string term, int limit = 15)
        {
            return users.Where(x => x.UserName.Contains(term) || x.Email.Contains(term))
                .Include(x => x.UserRoles.Where(y => y.RoleId == role.Id))
                .OrderBy(x => x.UserName)
                .Take(limit)
                .ToList();
        }
        
        public static List<User> GetUsersWithUserRolesForRole(this DbSet<User> users, Role role)
        {
            return users
                .Include(x => x.UserRoles.Where(y => y.RoleId == role.Id))
                .Where(x => x.UserRoles.Any(y => y.RoleId == role.Id))
                .OrderBy(x => x.UserName)
                .ToList();
        }
    }
}