using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.SalesManagement
{
    [Table("CampaignResponses")]
    public class CampaignResponse : FullAuditedEntity
    {
        public virtual int CampaignId { get; set; }
        [ForeignKey("CampaignId")]
        public virtual Campaign CampaignFK { get; set; }
        public virtual int ContactId { get; set; }
        [ForeignKey("ContactId")]
        public virtual Prospect ProspectFK { get; set; }
        [MaxLength(250)]
        public virtual string Message { get; set; }
        [MaxLength(500)]
        public virtual string Detail { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
