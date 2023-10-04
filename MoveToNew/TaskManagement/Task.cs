using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Facile.Governance.AssetTracker;
using MoveToNew.TimesheetManagement;

namespace Facile.Governance.TaskManagement
{
    [Table("Tasks")]
    public class Task : FullAuditedEntity
    {
        [MaxLength(500)]
        public virtual string Name { get; set; }

        [MaxLength(2000)]
        public virtual string Description { get; set; }
        public virtual int? Status { get; set; }
        [ForeignKey("Status")]
        public virtual TaskStatus StatusFk { get; set; }
        public virtual int? StatusesId { get; set; }
        [ForeignKey("StatusesId")]
        public virtual Status StatusesFK { get; set; }
        public virtual DateTimeOffset? DueDate { get; set; }
        public virtual int? TemplateId { get; set; }
        [ForeignKey("TemplateId")]
        public virtual TaskTemplate TaskTemplateFk { get; set; }
        public virtual long? AssignTo { get; set; }
        [ForeignKey("AssignTo")]
        public virtual User AssignUserFk { get; set; }
        public virtual DateTimeOffset? CompletedDate { get; set; }
        public virtual long? WaitingOnUser { get; set; }
        [ForeignKey("WaitingOnUser")]
        public virtual User WaitingOnUserFk { get; set; }
        public virtual int? WaitingOnVendor { get; set; }
        [ForeignKey("WaitingOnVendor")]
        public virtual Vendor WaitingOnVendorFk { get; set; }
        public virtual string Note { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
