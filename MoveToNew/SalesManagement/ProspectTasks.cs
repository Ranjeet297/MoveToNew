using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Facile.Governance.SalesManagement
{
    public class ProspectTasks : FullAuditedEntity
    {
        [Required]
        public virtual string TaskName { get; set; }
        [Required]
        public virtual string Description { get; set; }
        public virtual string AssignedTo { get; set; }
        public virtual DateTimeOffset? DueDate { get; set; }

        public virtual int ProspectId { get; set; }
        [ForeignKey("ProspectId")]
        public virtual Prospect ProspectFk { get; set; }
        public virtual DateTimeOffset? CompletedDate { get; set; }

    }
}
