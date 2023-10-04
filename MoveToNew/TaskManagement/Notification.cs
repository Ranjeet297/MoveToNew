using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using MoveToNew.TimesheetManagement;

namespace Facile.Governance.TaskManagement
{
    public class Notification : FullAuditedEntity
    {
        [MaxLength(250)]
        public virtual string Name { get; set; }
        [MaxLength(250)]
        public virtual string Type { get; set; }
        public virtual long? TypeId { get; set; }
        [MaxLength(250)]
        public virtual string TypeBehaviour { get; set; }
        public virtual long? AssignToUser { get; set; }
        [ForeignKey("AssignToUser")]
        public virtual User AssignToUserFk { get; set; }
        public virtual long? AssignByUser { get; set; }
        [ForeignKey("AssignByUser")]
        public virtual User AssignByUserFk { get; set; }
        public bool IsRead { get; set; }
    }
}
