using Abp.Domain.Entities.Auditing;
using Facile.Governance.AppraisalManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.LeaveManagement
{
    public class EmployeeSalarySettings : FullAuditedEntity
    {
        [Required]
        public virtual int EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee EmployeeFK { get; set; }
        [Required]
        public virtual int SalarySettingsID { get; set; }
        [ForeignKey("SalarySettingsID")]

        public virtual SalarySettings SalarySettingsFK { get; set; }
        public virtual string Formula { get; set; }
        [Required]
        public virtual decimal? Amount { get; set; }
        [Required]
        public virtual int EmployeeTypeId { get; set; }
        [ForeignKey("EmployeeTypeId")]
        public virtual EmployeeType EmployeeTypeFK { get; set; }

        public virtual int? TypesId { get; set; }
        [ForeignKey("TypesId")]

        public virtual Facile.Governance.Common.Type TypesFk { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
