using Abp.Domain.Entities.Auditing;
using Facile.Governance.AssetTracker;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.TaskManagement
{
    [Table("TemplateTasks")]
    public class TemplateTask : FullAuditedEntity
    {
        public virtual string Name { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int? Status { get; set; }
        [ForeignKey("Status")]
        public virtual TaskStatus TaskStatus { get; set; }

        public virtual int? StatusesId { get; set; }
        [ForeignKey("StatusesId")]
        public virtual Status StatusesFK { get; set; }
        public virtual int? TemplateId { get; set; }
        [ForeignKey("TemplateId")]
        public virtual TaskTemplate TaskTemplates{ get; set; }
        public virtual int DayOfMonth { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
