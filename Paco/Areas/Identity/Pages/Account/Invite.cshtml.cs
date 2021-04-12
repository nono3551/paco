using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Paco.Entities.Models;
using Paco.Entities.Models.Identity;
using Paco.Repositories.Database;

namespace Paco.Areas.Identity.Pages.Account
{
    public class SetPasswordModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public SetPasswordModel(UserManager<User> userManager, SignInManager<User> signInManager, IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContextFactory = dbContextFactory;
        }

        [BindProperty(SupportsGet = true)]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Email")]
            public string Email { get; set; }
            
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "New password")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm new password")]
            [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(Guid invite)
        {
            await _signInManager.SignOutAsync();
            
            
            var emailInvite = _dbContextFactory.Find<EmailInvite>(invite);
            
            if (emailInvite == null)
            {
                return NotFound($"Unable find invite.");
            }

            if (!emailInvite.IsValid)
            {
                return BadRequest("Invite is not valid anymore. Request new invite.");
            }
            
            var user = await _userManager.FindByEmailAsync(emailInvite.Email);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);

            if (hasPassword)
            {
                await _signInManager.SignInAsync(user, true);
                return LocalRedirect(Url.Content("~/Identity/Account/Manage"));
            }

            Input.Email = emailInvite.Email;
            
            ModelState.SetModelValue("Email", new ValueProviderResult(Input.Email, CultureInfo.InvariantCulture));

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid invite)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emailInvite = _dbContextFactory.Find<EmailInvite>(invite);
            
            if (emailInvite == null)
            {
                return NotFound($"Unable find invite.");
            }

            if (!emailInvite.IsValid)
            {
                return BadRequest("Invite is not valid anymore. Request new invite.");
            }
            
            var user = await _userManager.FindByEmailAsync(emailInvite.Email);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var addPasswordResult = await _userManager.AddPasswordAsync(user, Input.NewPassword);
            if (!addPasswordResult.Succeeded)
            {
                foreach (var error in addPasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmResult = _userManager.ConfirmEmailAsync(user, code);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your password has been set.";

            emailInvite.Used = true;

            _dbContextFactory.Upsert(emailInvite);
            
            return LocalRedirect(Url.Content("~/Identity/Account/Manage"));
        }
    }
}
