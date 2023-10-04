using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.InvoiceManagement
{
    [Table("Taxes")]
    public class Tax : FullAuditedEntity
    {
        [MaxLength(50)]
        public virtual string Name { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public virtual decimal Taxes { get; set; }

        public virtual bool IsActive { get; set; }
    }
}
