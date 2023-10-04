using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.TaskManagement
{
    [Table("ReminderSettings")]
    public class ReminderSettings : FullAuditedEntity
    {
        public virtual int? ReminderAfterInternel { get; set; }
        public virtual int? ReminderBeforeInternel { get; set; }
        public virtual int? ReminderAfterExternel { get; set; }
        public virtual int? ReminderBeforeExternel { get; set; }
    }
}
