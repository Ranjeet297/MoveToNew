using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Facile.Governance.InvoiceManagement
{
    [Table ("InvoiceItems")]
    public class InvoiceItem: FullAuditedEntity
    {
        public virtual int ProjectResourceId { get; set; }
        [ForeignKey("ProjectResourceId")]
        public virtual ProjectResource  ProjectResourceFK { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public virtual decimal Hours { get; set; }       
        
        [MaxLength(250)]
        public virtual string Service { get; set; }

        public virtual int InvoiceId { get; set; }                  
        [ForeignKey("InvoiceId")]
        public virtual Invoice InvoiceFK { get; set; }

        public virtual bool IsActive { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public virtual decimal HourRate { get; set; }
    }          
}
