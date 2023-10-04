using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Facile.Governance.CashManagement
{
    public class CMCashRegister : FullAuditedEntity
    {
        public virtual int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual CMType TypeIdFk { get; set; }
        public virtual int? TypesId { get; set; }
        [ForeignKey("TypesId")]

        public virtual Facile.Governance.Common.Type TypesFk { get; set; }
        public virtual int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual CMCategory CategoryIdFk { get; set; }
        public virtual int? VendorId { get; set; }
        [ForeignKey("VendorId")]
        public virtual CMVendor VendorIdFk { get; set; }
        public virtual DateTimeOffset? ExpenseDate { get; set; }

        [MaxLength(500)]
        public virtual string Description { get; set; }

        [MaxLength(500)]
        public virtual string? Memo { get; set; }

        [Required]
        [Range(0, 9999999999.99)]
        public virtual decimal Amount { get; set; }
        [Required]
        [Range(0, 9999999999.99)]
        public virtual decimal Balance { get; set; }
        public virtual bool VoucherPrepared { get; set; }
        public virtual bool VoucherSigned { get; set; }
        public virtual bool BillRecevied { get; set; }

        [MaxLength(150)]
        public virtual string VoucherNo { get; set; }

        [MaxLength(150)]
        public virtual string BillNo { get; set; }

        [MaxLength(500)]
        public virtual string VoucherDetail { get; set; }

        [MaxLength(500)]
        public virtual string BillDetail { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }

    }
}
