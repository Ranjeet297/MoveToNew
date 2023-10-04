using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.SalesManagement
{
    [Table("CampaignUnsubscribed")]
    public class CampaignUnsubscribe : FullAuditedEntity
    {
        public virtual int ContactId { get; set; }
        [ForeignKey("ContactId")]
        public virtual CampaignContact CampaignContactFk { get; set; }
    }
}
