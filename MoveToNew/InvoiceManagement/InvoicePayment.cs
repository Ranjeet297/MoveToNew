using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.InvoiceManagement
{
    public class InvoicePayment : FullAuditedEntity
    {
        public virtual int InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual Invoice InvoiceFk { get; set; }

        public virtual int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client ClientFk { get; set; }

        public virtual int? ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project ProjectFk { get; set; }

        public virtual int CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual Currency CurrenyFk { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public virtual decimal Multiplier { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public virtual decimal Total { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }

    }
}
