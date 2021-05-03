using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Paco.Entities;
using Paco.Entities.Models;
using Paco.Entities.Models.Identity;
using Paco.Repositories.Database;

namespace Paco.Services
{
    public class UserInviteService
    {
        private readonly UserManager<User> _userManager;
        private IDbContextFactory<ApplicationDbContext> DbContextFactory { get; }
        private EmailQueueService EmailQueueService { get; }

        public UserInviteService(IDbContextFactory<ApplicationDbContext> dbContextFactory,
            EmailQueueService emailQueueService, UserManager<User> userManager)
        {
            _userManager = userManager;
            DbContextFactory = dbContextFactory;
            EmailQueueService = emailQueueService;
        }

        private async Task<User> CreateUser(string emailAddress)
        {
            var user = await _userManager.FindByEmailAsync(emailAddress);

            if (user == null)
            {
                await _userManager.CreateAsync(new User {UserName = emailAddress, Email = emailAddress});
                user = await _userManager.FindByEmailAsync(emailAddress);
            }

            return user;
        }

        private async Task SetAllPreviousInvitesAsUnused(string email)
        {
            await using var context = DbContextFactory.CreateDbContext();
            context.EmailInvites.Where(x => !x.Used && x.Email == email).ToList().ForEach(x => x.Used = false);
            await context.SaveChangesAsync();
        }

        public async Task<User> InviteNewAdministrator(string email)
        {
            await SetAllPreviousInvitesAsUnused(email);

            var user = await CreateUser(email);

            EmailQueueService.InviteUser(DbContextFactory.Upsert(new EmailInvite()
                {
                    InviterId = user.Id,
                    Email = email,
                    TargetId = user!.Id
                })
            );

            return user;
        }

        public async Task InviteUser(UserInviteModel userInviteModel)
        {
            await SetAllPreviousInvitesAsUnused(userInviteModel.Email);

            var user = await CreateUser(userInviteModel.Email);

            EmailQueueService.InviteUser(DbContextFactory.Upsert(new EmailInvite()
                {
                    InviterId = userInviteModel.Inviter.Id,
                    Email = userInviteModel.Email,
                    TargetId = user!.Id
                })
            );
        }
    }
}