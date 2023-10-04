using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Facile.Governance.SalesManagement
{
    public class ProspectMeeting : FullAuditedEntity
    {
        [Required]
        public virtual string Description { get; set; }
        public virtual DateTimeOffset? Date { get; set; }
        public virtual DateTimeOffset? Time { get; set; }
        public virtual int DurationId { get; set; }
        [ForeignKey("DurationId")]
        public virtual Duration DurationFK { get; set; }
        public virtual int ProspectId { get; set; }
        [ForeignKey("ProspectId")]
        public virtual Prospect ProspectFk { get; set; }
    }
}
