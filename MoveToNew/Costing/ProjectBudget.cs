using Abp.Domain.Entities.Auditing;
using Facile.Governance.TimesheetManagement;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.Costing
{
    [Table("ProjectBudget")]
    public class ProjectBudget : FullAuditedEntity
    {

        public virtual int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual TimesheetProject ProjectIdFk { get; set; }


        public virtual int? ChangeReqTrackingId { get; set; }
        [ForeignKey("ChangeReqTrackingId")]
        public virtual ChangeRequestTracking ChangeRequestTrackingIdFk { get; set; }


        public virtual int BudgetSettingId { get; set; }
        [ForeignKey("BudgetSettingId")]
        public virtual BudgetSet BudgetSettingIdFk { get; set; }


        [Column(TypeName = "decimal(10, 2)")]
        public virtual decimal? Amount { get; set; }


    }
}
