using System;

namespace Paco.Entities.Models
{
    public interface IDbEntity
    {
        DateTime? DeletedAt { get; set; }
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
