using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Facile.Governance.AssetTracker;
using Facile.Governance.InvoiceManagement;
using Facile.Governance.TimesheetManagement;

namespace MoveToNew.TimesheetManagement
{

    public class Timesheet : FullAuditedEntity
    {
        [MaxLength(500)]
        public virtual string? Description { get; set; }
        [Required]

        public virtual DateTimeOffset? StartTime { get; set; }
        [Required]

        public virtual DateTimeOffset? EndTime { get; set; }
        [Required]

        public virtual DateTimeOffset? Day { get; set; }
        public virtual int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual TimesheetProject ProjectIdFk { get; set; }
        public virtual int? ProjectsId { get; set; }
        [ForeignKey("ProjectsId")]
        public virtual Project ProjectsFk { get; set; }
        public virtual int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual TimesheetStatus StatusIdFk { get; set; }
        public virtual int? StatusesId { get; set; }
        [ForeignKey("StatusesId")]
        public virtual Status? StatusesFK { get; set; }
        public virtual long? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User? UserIdFk { get; set; }

        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
