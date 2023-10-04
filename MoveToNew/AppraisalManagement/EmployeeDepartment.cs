using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Facile.Governance.AppraisalManagement
{
    public class EmployeeDepartment : FullAuditedEntity
    {
        public virtual int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee EmployeeIdFk { get; set; }
        public virtual int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department DepartmentIdFk { get; set; }



    }
}
