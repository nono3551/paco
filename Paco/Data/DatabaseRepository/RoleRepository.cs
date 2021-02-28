using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Paco.Data.Entities.Identity;

namespace Paco.Data.DatabaseRepository
{
    public static class RoleRepository
    {
        public static Role GetRoleWithUsers(this DbSet<Role> roles, Guid roleId)
        {
            return roles.Where(r => r.Id == roleId).Include(s => s.Users).FirstOrDefault();
        }
    }
}