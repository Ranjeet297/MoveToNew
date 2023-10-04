using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Facile.Governance.SalesManagement
{
    [Table("CampaignContacts")]
    public class CampaignContact : FullAuditedEntity
    {
        public virtual int CampaignId { get; set; }
        [ForeignKey("CampaignId")]
        public virtual Campaign CampaignFk { get; set; }
        public virtual int ProspectId { get; set; }
        [ForeignKey("ProspectId")]
        public virtual Prospect ProspectFk { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsSent { get; set; }
        public virtual bool IsBoundced { get; set; }
        public virtual bool IsOpened { get; set; }
        public virtual DateTimeOffset SentOn { get; set; }
        public virtual DateTimeOffset OpenedOn { get; set; }
        public virtual string Token { get; set; }
        public virtual bool IsUnsubscribed { get; set; }
        public virtual DateTimeOffset LastOpened { get; set; }
        public virtual bool Click { get; set; }
        public virtual int ClickCount { get; set; }
        public virtual DateTimeOffset LastClickDate { get; set; }
        public virtual DateTimeOffset UndsubscribeDate { get; set; }
        public virtual int OpenedCount { get; set; }



    }
}
