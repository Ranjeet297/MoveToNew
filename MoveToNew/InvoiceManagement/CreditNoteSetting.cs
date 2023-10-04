using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.InvoiceManagement
{
    [Table("CreditNoteSettings")]
    public class CreditNoteSetting : FullAuditedEntity
    {
        [MaxLength(50)]
        public virtual string? CreditNotePrefix { get; set; }

        [Required]
        [MaxLength(50)]
        public virtual string CreditNoteStart { get; set; }

        [MaxLength(50)]
        public virtual string? CreditNoteSuffix { get; set; }
    }
}
