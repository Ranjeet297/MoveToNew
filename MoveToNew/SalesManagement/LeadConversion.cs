using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.SalesManagement
{
    [Table("LeadConversions")]
    public class LeadConversion:FullAuditedEntity
    {
        public virtual int LeadId { get; set; }
        [ForeignKey("LeadId")]
        public virtual Lead LeadFK { get; set; }
        public virtual int ConversionTypeId { get; set; }
        [ForeignKey("ConversionTypeId")]
        public virtual LeadConversionType ConversionTypeFk { get; set; }
        public virtual int? TypesId { get; set; }
        [ForeignKey("TypesId")]

        public virtual Facile.Governance.Common.Type TypesFk { get; set; }
        [Required]
        [MaxLength(500)]
        public virtual string Note { get; set; }
        public virtual int? AttachmentId { get; set; }
        [ForeignKey("AttachmentId")]
        public virtual LeadAttachment AttachmentFk{ get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
