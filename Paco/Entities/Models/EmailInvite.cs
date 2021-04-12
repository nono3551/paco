using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Paco.Entities.Models.Identity;

namespace Paco.Entities.Models
{
    public class EmailInvite: IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public bool Used { get; set; }
        
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        
        public Guid InviterId { get; set; }
        public Guid TargetId { get; set; }
        
        public DateTime? DeletedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public bool IsValid => !Used && CreatedAt.HasValue && (DateTime.Now < CreatedAt.Value.Date.AddDays(1));
        
        public User Inviter { get; set; }
        public User Target { get; set; }
    }
}