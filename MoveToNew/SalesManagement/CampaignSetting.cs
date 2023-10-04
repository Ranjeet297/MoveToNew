using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.SalesManagement
{
    [Table("CampaignSettings")]
    public class CampaignSetting: FullAuditedEntity
    {
        public virtual int CampaignId { get; set; }
        [ForeignKey("CampaignId")]
        public virtual Campaign CampaignFk { get; set; }
        public virtual bool IsAutomatic { get; set; }
        public virtual int CampaignEmailId { get; set; }
        [ForeignKey("CampaignEmailId")]
        public virtual CampaignEmail CampaignEmailFk { get; set; }
        public virtual bool IsActive { get; set; }        
    }
}
