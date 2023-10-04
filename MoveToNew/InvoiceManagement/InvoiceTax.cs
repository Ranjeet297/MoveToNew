using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;


namespace Facile.Governance.InvoiceManagement
{
    [Table("InvoiceTaxs")]
    public class InvoiceTax: FullAuditedEntity
    {
        public virtual int InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual Invoice InvoiceFK { get; set; }

        public virtual int ProjectTaxId { get; set; }
        [ForeignKey("ProjectTaxId")]
        public virtual ProjectTax ProjectTaxFK { get; set; }

        public virtual bool IsActive { get; set; }
        
    }
}
