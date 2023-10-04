using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.TaskManagement
{
    [Table("TaskTemplates")]
    public class TaskTemplate : FullAuditedEntity
    {
        [MaxLength(500)]
        public virtual string Name { get; set; }

        [MaxLength(2000)]
        public virtual string Description { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
