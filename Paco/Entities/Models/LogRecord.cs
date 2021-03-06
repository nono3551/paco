using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paco.Entities.Models
{
    public class LogRecord: IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Message { get; set; }

        public string MessageTemplate { get; set; }

        [MaxLength(128)]
        public string Level { get; set; }

        public DateTimeOffset TimeStamp { get; set; }

        public string Exception { get; set; }

        public string LogEvent { get; set; }

        public int? EventId { get; set; }

        public string SourceContext { get; set; }

        public string ActionId { get; set; }

        public string ActionName { get; set; }

        public string RequestId { get; set; }

        public string RequestPath { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        public DateTime? DeletedAt { get; set; }
    }
}