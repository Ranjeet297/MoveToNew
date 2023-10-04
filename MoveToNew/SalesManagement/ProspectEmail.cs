using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Facile.Governance.SalesManagement
{
    public class ProspectEmail : FullAuditedEntity
    {
        [Required]
        public virtual string To { get; set; }
        [Required]
        public virtual int FromId { get; set; }
        [ForeignKey("FromId")]
        public virtual MailBoxes FromFK { get; set; }
        public virtual string CC { get; set; }
        public virtual string BCC { get; set; }
        [Required]

        public virtual string Subject { get; set; }
        [Required]

        public virtual string Body { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTimeOffset? Date { get; set; }
        public virtual DateTimeOffset? Time { get; set; }
        public virtual int ProspectId { get; set; }
        [ForeignKey("ProspectId")]
        public virtual Prospect ProspectFk { get; set; }

    }
}
