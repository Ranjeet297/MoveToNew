using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Facile.Governance.InvoiceManagement
{
    [Table("InvoiceSettings")]
    public class InvoiceSetting: FullAuditedEntity
    {
        [MaxLength(50)]
        public virtual string InvoicePrefix { get; set; }

        [MaxLength(50)]
        public virtual string InvoiceStart { get; set; }

        [MaxLength(50)]
        public virtual string InvoiceSuffix { get; set; }
    }
}
