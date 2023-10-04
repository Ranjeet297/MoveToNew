using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using MoveToNew.TimesheetManagement;

namespace Facile.Governance.SalesManagement
{
    [Table("SalesTargets")]
    public class SalesTarget: FullAuditedEntity
    {
        [MaxLength(250)]
        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual DateTimeOffset StartDate { get; set; }

        [Required]
        public virtual DateTimeOffset EndDate { get; set; }

        [MaxLength(500)]
        public virtual string Detail { get; set; }

        public virtual long UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User UserFK { get; set; }

        public virtual int TargetTypeId { get; set; }
        [ForeignKey("TargetTypeId")]
        public virtual SalesTargetType SalesTargetTypeFK { get; set; }
        public virtual int? TypesId { get; set; }
        [ForeignKey("TypesId")]

        public virtual Facile.Governance.Common.Type TypesFk { get; set; }

        public virtual string SalesTargetStatus { get; set; }
        public virtual int Target { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }

    }
}
