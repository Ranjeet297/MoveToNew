using Abp.Domain.Entities.Auditing;
using Facile.Governance.AssetTracker;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.SalesManagement
{
    [Table("Campaigns")]
    public class Campaign : FullAuditedEntity
    {
        [MaxLength(250)]
        [Required]
        public virtual string Name { get; set; }
        public virtual int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual CampaignType CampaignTypeFK { get; set; }
        public virtual int? TypesId { get; set; }
        [ForeignKey("TypesId")]
        public virtual Facile.Governance.Common.Type TypesFk { get; set; }
        public virtual int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual CampaignStatus CampaignStatusFK { get; set; }
        public virtual int? StatusesId { get; set; }
        [ForeignKey("StatusesId")]
        public virtual Status StatusesFK { get; set; }
        public virtual bool IsActive { get; set; }
        [Required]
        public virtual string FromName { get; set; }
        [Required]
        [MaxLength(250)]
        public virtual string FromEmail { get; set; }
        [Required]
        [MaxLength(250)]
        public virtual string ReplyTo { get; set; }
        [Required]
        [MaxLength(500)]
        public virtual string Segments { get; set; }
        public virtual int? MailSenderId { get; set; }
        [ForeignKey("MailSenderId")]
        public virtual Mailsender MailSenderIdFk { get; set; }
        public virtual DateTimeOffset? StartTime { get; set; }
        public virtual DateTimeOffset? EndTime { get; set; }

        public virtual string? TimeZone { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }

    }
}
