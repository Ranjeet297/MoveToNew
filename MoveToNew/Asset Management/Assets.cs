using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using MoveToNew.TimesheetManagement;

namespace Facile.Governance.AssetTracker
{
    public class Assets : FullAuditedEntity
    {
        [MaxLength(250)]
        [Required]
        public virtual string Name { get; set; }
        public virtual string SerialNo { get; set; }

        public virtual int TypeId { get; set; }
        [ForeignKey("TypeId")]

        public virtual AssetType TypeIdFk { get; set; }
        public virtual int? TypesId { get; set; }
        [ForeignKey("TypesId")]

        public virtual Facile.Governance.Common.Type TypesFk { get; set; }

        public virtual int BrandId { get; set; }
        [ForeignKey("BrandId")]

        public virtual Brand BrandIdFk { get; set; }
        public virtual float Price { get; set; }

        [MaxLength(500)]
        public virtual string Details { get; set; }
        public virtual DateTimeOffset? PurchaseDate { get; set; }

        [MaxLength(250)]
        public virtual string PurchaseBill { get; set; }
        public virtual DateTimeOffset? WarrantyFromDate { get; set; }
        public virtual DateTimeOffset? WarrantyToDate { get; set; }
        public virtual int OrderNo { get; set; }
        public virtual int StatusId { get; set; }
        [ForeignKey("StatusId")]
        [Required]
        public virtual Status StatusIdFk { get; set; }

        [MaxLength(500)]
        public virtual string? RepairReason { get; set; }

        [MaxLength(250)]
        public virtual string? RepairBill { get; set; }

        [MaxLength(500)]
        public virtual string OtherDetails { get; set; }
        public virtual long? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User UserIdFk { get; set; }

        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
