using Abp.Domain.Entities.Auditing;
using Facile.Governance.AssetTracker;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facile.Governance.InvoiceManagement
{
    public class CreditNote : FullAuditedEntity
    {
        [MaxLength(50)]
        public virtual string Name { get; set; }

        public virtual int InvoiceStatusId { get; set; }
        [ForeignKey("InvoiceStatusId")]
        public virtual InvoiceStatus InvoiceStatusFK { get; set; }
        public virtual int? StatusesId { get; set; }
        [ForeignKey("StatusesId")]
        public virtual Status StatusesFK { get; set; }

        [MaxLength(250)]
        public virtual string Description { get; set; }

        public virtual int? ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project ProjectFK { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public virtual decimal? SubTotal { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public virtual decimal? Total { get; set; }

        public virtual DateTimeOffset? SentDate { get; set; }

        public virtual DateTimeOffset? PaidDate { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual int CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual Currency CurrencyFk { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public virtual decimal? Multiplier { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public virtual decimal? INRTotal { get; set; }

        [MaxLength(100)]
        public virtual string CreditNoteNumber { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
