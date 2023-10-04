using Abp.Domain.Entities.Auditing;
using Facile.Governance.TimesheetManagement;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.Costing
{
    public class ProjectAmountRequest : FullAuditedEntity
    {
        public virtual int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual TimesheetProject ProjectIdFk { get; set; }


        public virtual int ChangeReqestTrakingId { get; set; }
        [ForeignKey("ChangeReqestTrakingId")]
        public virtual ChangeRequestTracking ChangeReqestTrakingIdFk { get; set; }

        [MaxLength(250)]
        public virtual string Note { get; set; }


        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public virtual decimal? AmountRecived { get; set; }

        [Required]
        public virtual DateTimeOffset? InvoiceDate { get; set; }


        [MaxLength(20)]
        public virtual string InvoiceNo { get; set; }


    }
}
