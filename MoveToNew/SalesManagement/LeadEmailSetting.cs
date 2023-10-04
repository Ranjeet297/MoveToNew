using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;


namespace Facile.Governance.SalesManagement
{
    [Table("LeadEmailSettings")]
    public class LeadEmailSetting : FullAuditedEntity
    {
        public virtual int? LeadId { get; set; }
        [ForeignKey("LeadId")]
        public virtual Lead LeadFK { get; set; }

        public virtual int FollowupDay { get; set; }

        public virtual int LeadContactId { get; set; }
        [ForeignKey("LeadContactId")]
        public virtual LeadContact LeadContactFK { get; set; }

        public virtual int? LeadAttachmentId { get; set; }

        [ForeignKey("LeadAttachmentId")]
        public virtual LeadAttachment LeadAttachmentFK { get; set; }

    }
}
