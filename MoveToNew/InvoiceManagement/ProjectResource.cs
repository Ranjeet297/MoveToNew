using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Facile.Governance.InvoiceManagement
{
    [Table("ProjectResources")]
    public class ProjectResource : FullAuditedEntity
    {
        public virtual int? ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project ProjectFK { get; set; }

        public virtual int ResourceId { get; set; }
        [ForeignKey("ResourceId")]
        public virtual Resource ResourceFK { get; set; }

        public virtual DateTimeOffset StartDate { get; set; }
        public virtual DateTimeOffset? EndDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public virtual decimal? MaxHours { get; set; }

        public virtual int PositionId { get; set; }
        [ForeignKey("PositionId")]
        public virtual Position PositionFK { get; set; }

        public string Service { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public virtual decimal HourRate { get; set; }

        public virtual bool IsActive { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }

    }
}
