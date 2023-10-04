using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.SalesManagement
{
    [Table("EmailTemplates")]
    public class EmailTemplate: FullAuditedEntity
    {
        [MaxLength(250)]
        [Required]
        public virtual string Name { get; set; }
        [MaxLength(250)]
        [Required]
        public virtual string Subject { get; set; }    
        [Required]
        public virtual string Body { get; set; }
        public virtual int EmailTemplateTypeId { get; set; }
        [ForeignKey("EmailTemplateTypeId")]
        public virtual EmailTemplateType EmailTemplateTypeFK { get; set; }
        public virtual int? TypesId { get; set; }
        [ForeignKey("TypesId")]

        public virtual Facile.Governance.Common.Type TypesFk { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
