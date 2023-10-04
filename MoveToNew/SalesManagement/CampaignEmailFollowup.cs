using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.SalesManagement
{
    [Table("CampaignEmailFollowups")]
    public class CampaignEmailFollowup: FullAuditedEntity
    {
        public virtual int CampaignEmailId { get; set; }
        [ForeignKey("CampaignEmailId")]
        public virtual CampaignEmail CampaignEmailFk { get; set; }
        public virtual int FollowupDay { get; set; }
        public virtual int EmailId { get; set; }
        [ForeignKey("EmailId")]
        public virtual EmailTemplate EmailTempalateNewFK { get; set; }
        public virtual int? CampaignAttachmentId { get; set; }
        [ForeignKey("CampaignAttachmentId")]
        public virtual CampaignAttachment CampaignAttachmentFK { get; set; }
        public bool IsActive { get; set; }
    }
}
