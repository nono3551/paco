using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Paco.Entities.Models.Identity;

namespace Paco.Repositories.Database
{
    public static class RoleRepository
    {
        public static Role GetRole(this DbSet<Role> roles, Guid roleId)
        {
            return roles.FirstOrDefault(r => r.Id == roleId);
        }
    }
}