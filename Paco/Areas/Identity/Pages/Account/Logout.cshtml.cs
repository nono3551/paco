using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Paco.Entities.Models.Identity;

namespace Paco.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<User> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnGet(string returnUrl = null)
        {
            return await Logout(returnUrl);
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            return await Logout(returnUrl);
        }

        private async Task<IActionResult> Logout(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                await _signInManager.SignOutAsync();
                _logger.LogInformation("User logged out.");
            }
            
            return LocalRedirect(returnUrl);
        }
    }
}
