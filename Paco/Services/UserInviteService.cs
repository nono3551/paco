using System;
using System.Linq;
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

        public UserInviteService(IDbContextFactory<ApplicationDbContext> dbContextFactory, EmailQueueService emailQueueService, UserManager<User> userManager)
        {
            _userManager = userManager;
            DbContextFactory = dbContextFactory;
            EmailQueueService = emailQueueService;
        }
        
        public async void InviteUser(UserInviteModel userInviteModel)
        {
            await using var context = DbContextFactory.CreateDbContext();
            context.EmailInvites.Where(x => !x.Used && x.Email == userInviteModel.Email).ToList().ForEach(x => x.Used = false);
            await context.SaveChangesAsync();

            
            var user = await _userManager.FindByEmailAsync(userInviteModel.Email);

            if (user == null)
            {
                var result = await _userManager.CreateAsync(new User { UserName = userInviteModel.Email, Email = userInviteModel.Email });
                user = await _userManager.FindByEmailAsync(userInviteModel.Email);
            }

            var userInvite = new EmailInvite()
            {
                InviterId = userInviteModel.Inviter.Id,
                Email = userInviteModel.Email,
                TargetId = user!.Id
            };

            DbContextFactory.Upsert(userInvite);

            var invite = context.EmailInvites.Where(x => x == userInvite).Include(x => x.Inviter).Include(x => x.Target).FirstOrDefault();
            
            EmailQueueService.InviteUser(invite);
        }
    }
}