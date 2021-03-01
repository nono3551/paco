using System;
using System.ComponentModel;

namespace Paco.Data.Entities
{
    public interface IDbEntity
    {
        [DefaultValue(false)]
        bool IsDeleted { get; set; }
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
