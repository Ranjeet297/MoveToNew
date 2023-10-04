using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using MoveToNew.TimesheetManagement;

namespace Facile.Governance.AppraisalManagement
{
    [Table("Employees")]

    public class Employee : FullAuditedEntity
    {
        [MaxLength(50)]
        public virtual string EmployeeCode { get; set; }

        [MaxLength(250)]
        [Required]
        public virtual string FirstName { get; set; }

        [MaxLength(250)]
        [Required]
        public virtual string LastName { get; set; }

        [MaxLength(250)]
        [Required]
        public virtual string Email { get; set; }

        [MaxLength(50)]
        [Required]
        public virtual string MobileNo { get; set; }
        [Required]
        public virtual DateTimeOffset? DateOfBirth { get; set; }

        [MaxLength(250)]
        [Required]
        public virtual string Address { get; set; }
        public virtual int DesignationId { get; set; }
        [ForeignKey("DesignationId")]
        public virtual Designation DesignationIdFk { get; set; }

        [MaxLength(50)]
        public virtual string Proof { get; set; }

        [MaxLength(50)]
        public virtual string TotalExperience { get; set; }
        public virtual long Salary { get; set; }

        public virtual long UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User UserIdFk { get; set; }




    }
}
