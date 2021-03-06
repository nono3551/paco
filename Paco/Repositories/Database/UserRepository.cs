using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Paco.Entities.Models.Identity;

namespace Paco.Repositories.Database
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
                .Where(x => x.UserRoles.Any(y => y.RoleId == role.Id))
                .Include(x => x.UserRoles.Where(y => y.RoleId == role.Id))
                .OrderBy(x => x.UserName)
                .ToList();
        }

        public static List<User> GetAllAdministrators(this DbSet<User> users)
        {
            return users.Where(x => x.EmailNotifications && x.Roles.Any(r => r.NormalizedName == "ADMINISTRATOR")).ToList();
        }
    }
}