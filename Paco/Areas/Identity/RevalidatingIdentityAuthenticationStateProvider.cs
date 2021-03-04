using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Paco.Areas.Identity
{
    public class RevalidatingIdentityAuthenticationStateProvider<TUser> : RevalidatingServerAuthenticationStateProvider where TUser : IdentityUser<Guid>
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IdentityOptions _options;

        public RevalidatingIdentityAuthenticationStateProvider(ILoggerFactory loggerFactory, IServiceScopeFactory scopeFactory, IOptions<IdentityOptions> optionsAccessor) : base(loggerFactory)
        {
            _scopeFactory = scopeFactory;
            _options = optionsAccessor.Value;
        }

        protected override TimeSpan RevalidationInterval => TimeSpan.FromSeconds(10);

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            using var scope = _scopeFactory.CreateScope();
            var userManager = scope.ServiceProvider.GetService<UserManager<TUser>>();
            var state = base.GetAuthenticationStateAsync().Result;
            var roles = await userManager!.GetRolesAsync(await userManager.GetUserAsync(state.User));
            var user = await userManager.GetUserAsync(state.User);
            var principalFactory = new UserClaimsPrincipalFactory<TUser>(userManager, new OptionsWrapper<IdentityOptions>(_options));
            var principal = await principalFactory.CreateAsync(user);
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(principal.Identity, roles.Select(role => new Claim(ClaimTypes.Role, role))));
            
            return new AuthenticationState(claimsPrincipal);
        }

        protected override async Task<bool> ValidateAuthenticationStateAsync(AuthenticationState authenticationState, CancellationToken cancellationToken)
        {
            // Get the user manager from a new scope to ensure it fetches fresh data
            var scope = _scopeFactory.CreateScope();
            try
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<TUser>>();
                
                if (!await ValidateRoles(userManager, authenticationState.User))
                {
                    NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
                }

                return await ValidateSecurityStampAsync(userManager, authenticationState.User);
            }
            finally
            {
                if (scope is IAsyncDisposable asyncDisposable)
                {
                    await asyncDisposable.DisposeAsync();
                }
                else
                {
                    scope.Dispose();
                }
            }
        }

        private async Task<bool> ValidateRoles(UserManager<TUser> userManager, ClaimsPrincipal principal)
        {
            var currentUser = await userManager.GetUserAsync(principal);
            var currentRoles = await userManager.GetRolesAsync(currentUser);

            var tokenRoles = principal.Claims.Where(x => x.Type == ClaimTypes.Role).ToList() ?? new List<Claim>();

            var rolesEqual = tokenRoles.Count() == currentRoles.Count() && tokenRoles.All(tokenRole => currentRoles.Contains(tokenRole.Value));

            return rolesEqual;
        }

        private async Task<bool> ValidateSecurityStampAsync(UserManager<TUser> userManager, ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal);
            if (user == null)
            {
                return false;
            }
            else if (!userManager.SupportsUserSecurityStamp)
            {
                return true;
            }
            else
            {
                var principalStamp = principal.FindFirstValue(_options.ClaimsIdentity.SecurityStampClaimType);
                var userStamp = await userManager.GetSecurityStampAsync(user);
                return principalStamp == userStamp;
            }
        }
    }
}
