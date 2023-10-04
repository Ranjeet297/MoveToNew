using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using MoveToNew.TimesheetManagement;

namespace Facile.Governance.AssetTracker
{
    public class Status : FullAuditedEntity
    {
        [MaxLength(250)]
        [Required]
        public virtual string Name { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int IdentyType { get; set; }
        [MaxLength(250)]
        public virtual string? Color { get; set; }
        public virtual long? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User? UserFk { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
