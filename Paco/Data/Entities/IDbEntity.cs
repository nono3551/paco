using System;
using System.ComponentModel;

namespace Paco.Data.Entities
{
    public interface IDbEntity
    {
        DateTime? DeletedAt { get; set; }
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
