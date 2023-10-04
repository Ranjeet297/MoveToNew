using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Facile.Governance.AppraisalManagement
{
    public class Appraisal : FullAuditedEntity
    {
        public virtual int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee EmployeeIdFk { get; set; }

        [MaxLength(250)]
        [Required]
        public virtual string AppraisalName { get; set; }
        [Required]
        public virtual DateTimeOffset? AppraisalDate { get; set; }
        [Required]
        public virtual float OverallRating { get; set; }



    }
}
