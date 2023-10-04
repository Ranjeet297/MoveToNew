using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.SalesManagement
{
    [Table("CampaignEmails")]
    public class CampaignEmail: FullAuditedEntity
    {
        [MaxLength(250)]
        [Required]
        public virtual string Name { get; set; }

        public virtual int EmailId { get; set; }
        [ForeignKey("EmailId")]
        public virtual EmailTemplate EmailTempalateFK { get; set; }

        public virtual int? CampaignAttachmentId { get; set; }
        [ForeignKey("CampaignAttachmentId")]
        public virtual CampaignAttachment CampaignAttachmentFK { get; set; }

        public bool IsActive { get; set; }
    }
}
