using Skyttus.Core.Entity;

namespace TimeTable.Models.Common
{
    public class AuditableBaseEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime DeletedAt { get; set; } = DateTime.Now;
    }
}
