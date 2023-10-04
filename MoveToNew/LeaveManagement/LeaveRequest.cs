using Abp.Domain.Entities.Auditing;
using Facile.Governance.AppraisalManagement;
using MoveToNew.TimesheetManagement;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.LeaveManagement
{
    public class LeaveRequest : FullAuditedEntity
    {
        [Required]
        public virtual int EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee EmployeeFK { get; set; }
        [Required]
        public virtual DateTimeOffset? LeaveFromDate { get; set; }
        [Required]
        public virtual DateTimeOffset? LeaveToDate { get; set; }
        [Required]
        public virtual string LeaveType { get; set; }

        public virtual bool? InCaseOfHalfDay { get; set; }
        [Required]
        public virtual DateTimeOffset? StartTime { get; set; }

        [Required]
        public virtual DateTimeOffset? EndTime { get; set; }
        [Required]
        public virtual DateTime DateOfLeave { get; set; }
        [Required]
        [MaxLength(500)]
        public virtual string ReasonForLeave { get; set; }
        [Required]
        public virtual bool? IsApproved { get; set; }
        [Required]
        public virtual long? ApprovedBy { get; set; }
        [ForeignKey("ApprovedBy")]
        public virtual User ApprovedByFk { get; set; }
        [Required]
        public virtual bool? IsDeclined { get; set; }
        [Required]
        public virtual long? DeclinedBy { get; set; }
        [ForeignKey("DeclinedBy")]
        public virtual User DeclinedByyFk { get; set; }
        [Required]
        [MaxLength(250)]
        public virtual string DeclineReason { get; set; }
        public virtual bool? IsTaken { get; set; }
        public virtual bool? IsCancelled { get; set; }
        public virtual bool? CancelledBy { get; set; }
        [Required]
        public virtual int PaidOrUnpaid { get; set; }
    }
}
