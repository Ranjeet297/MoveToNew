using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.InvoiceManagement
{
    [Table("Projects")]
    public class Project : FullAuditedEntity
    {
        [MaxLength(50)]
        public virtual string Name { get; set; }
        public virtual string? Description { get; set; }
        public virtual DateTimeOffset? StartDate { get; set; }
        public virtual DateTimeOffset? EndDate { get; set; }
        public virtual bool IsActive { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
