using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Facile.Governance.InvoiceManagement;
using MoveToNew.TimesheetManagement;

namespace Facile.Governance.TimesheetManagement
{
    public class TimesheetEmployeeProjects : FullAuditedEntity
    {
        public virtual int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual TimesheetProject ProjectIdFk { get; set; }
        public virtual int? ProjectsId { get; set; }
        [ForeignKey("ProjectsId")]
        public virtual Project ProjectsFk { get; set; }
        public virtual long? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User UserIdFk { get; set; }
        public virtual bool IsActive { get; set; }

        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
