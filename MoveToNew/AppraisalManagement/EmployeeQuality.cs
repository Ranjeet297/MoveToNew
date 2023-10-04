using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Facile.Governance.AppraisalManagement
{
    public class EmployeeQuality : FullAuditedEntity
    {
        public virtual int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee EmployeeIdFk { get; set; }

        public virtual int QualityId { get; set; }
        [ForeignKey("QualityId")]
        public virtual Quality QualityIdFk { get; set; }

    }
}
