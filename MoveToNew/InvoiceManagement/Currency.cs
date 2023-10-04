using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.InvoiceManagement
{
    [Table("Currencies")]
    public class Currency : FullAuditedEntity
    {
        [MaxLength(50)]
        public virtual string Name { get; set; }
        public virtual string DisplaySymbol { get; set; }
        public virtual string Symbol { get; set; }

        [Column(TypeName="decimal(10,2)")]
        public virtual decimal Multiplier { get; set; }

        public virtual bool IsActive { get; set; }
    }
}
