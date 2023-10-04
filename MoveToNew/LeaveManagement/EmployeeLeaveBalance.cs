using Abp.Domain.Entities.Auditing;
using Facile.Governance.AppraisalManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.LeaveManagement
{
    public class EmployeeLeaveBalance : FullAuditedEntity
    {
        [Required]
        public virtual int EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee EmployeeFK { get; set; }
        [Required]
        public virtual int LeaveBalance { get; set; }
        //[Required]
        //public virtual float? RemainingLeave { get; set; }
    }
}
