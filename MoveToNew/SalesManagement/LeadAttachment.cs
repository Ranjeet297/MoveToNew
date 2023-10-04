using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.SalesManagement
{
     [Table("LeadAttachments")]
    public class LeadAttachment : FullAuditedEntity
    {
        [Required]
        [MaxLength(250)]
        public virtual string Name { get; set; }
        public virtual int LeadId { get; set; }
        [ForeignKey("LeadId")]
        public virtual Lead LeadFK { get; set; }

        public virtual int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public virtual LeadAttachmentType TypeFK{ get; set; }
        public virtual int? TypesId { get; set; }
        [ForeignKey("TypesId")]

        public virtual Facile.Governance.Common.Type TypesFk { get; set; }

        [Required]
        [MaxLength(250)]
        public virtual string Url { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
