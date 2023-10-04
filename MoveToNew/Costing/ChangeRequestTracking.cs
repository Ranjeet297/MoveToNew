using Abp.Domain.Entities.Auditing;
using Facile.Governance.AppraisalManagement;
using Facile.Governance.AssetTracker;
using Facile.Governance.TimesheetManagement;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.Costing
{
    public class ChangeRequestTracking : FullAuditedEntity
    {
        [MaxLength(50)]
        [Required]
        public virtual string Name { get; set; }

        public virtual int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual TimesheetProject ProjectIdFk { get; set; }

        public virtual int PriorityId { get; set; }
        [ForeignKey("PriorityId")]
        public virtual Priority PriorityIdFk { get; set; }

        public virtual int ChangeReqStatusId { get; set; }
        [ForeignKey("ChangeReqStatusId")]
        public virtual ChangeReqStatus ChangeReqStatusIdFk { get; set; }
        public virtual int? StatusesId { get; set; }
        [ForeignKey("StatusesId")]
        public virtual Status StatusesFK { get; set; }

        [MaxLength(250)]
        public virtual string Description { get; set; }

        [Required]
        public virtual DateTimeOffset? PlannedStartTime { get; set; }

        [Required]
        public virtual DateTimeOffset? PlannedEndTime { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public virtual decimal? PlannedBudget { get; set; }

        [Required]
        public virtual DateTimeOffset? ActualStartTime { get; set; }

        [Required]
        public virtual DateTimeOffset? ActualEndTime { get; set; }


        [Column(TypeName = "decimal(10, 2)")]
        public virtual decimal? ActualBudget { get; set; }

        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
