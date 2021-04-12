using System.ComponentModel.DataAnnotations;
using Paco.Entities.Models.Identity;

namespace Paco.Entities
{
    public class UserInviteModel
    {
        [EmailAddress]
        public string Email { get; set; }

        public User Inviter { get; set; }
    }
}