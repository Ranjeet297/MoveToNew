using Abp.Domain.Entities.Auditing;
using Facile.Governance.AppraisalManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.LeaveManagement
{
    public class EmployeeAttendance : FullAuditedEntity
    {

        [Required]
        public virtual int EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee EmployeeFK { get; set; }
        [Required]
        public virtual int Month { get; set; }
        [Required]
        public virtual int Year { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day1 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day2 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day3 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day4 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day5 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day6 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day7 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day8 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day9 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day10 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day11 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day12 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day13 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day14 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day15 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day16 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day17 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day18 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day19 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day20 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day21 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day22 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day23 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day24 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day25 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day26 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day27 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day28 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day29 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day30 { get; set; }
        [Required]
        [MaxLength(5)]
        public virtual string Day31 { get; set; }
        [Required]
        public virtual decimal TotalLeaves { get; set; }
        public virtual decimal? PaidLeaves { get; set; }
        public virtual decimal? UNLeaves { get; set; }
        public virtual decimal? NotApplicable { get; set; }
        [Required]
        public virtual decimal SalaryDays { get; set; }

    }
}
