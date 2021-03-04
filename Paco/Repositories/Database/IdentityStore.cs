using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Paco.Entities.Models.Identity;

namespace Paco.Repositories.Database
{
    public class IdentityStore: UserStore<User, Role, ApplicationDbContext, Guid, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>
    {
        public IdentityStore(ApplicationDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
        
        protected override Task<UserRole> FindUserRoleAsync(Guid userId, Guid roleId, CancellationToken cancellationToken)
        {
            return Context.UserRoles.FirstOrDefaultAsync(x => x.RoleId == roleId && x.UserId == userId, cancellationToken: cancellationToken);
        }
    }
}