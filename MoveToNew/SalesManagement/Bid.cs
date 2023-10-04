using Abp.Domain.Entities.Auditing;
using Facile.Governance.AssetTracker;
using Facile.Governance.InvoiceManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.SalesManagement
{
    [Table("Bids")]
    public class Bid: FullAuditedEntity
    {
        [Required]
        [MaxLength(250)]
        public virtual string Name { get; set; }

        [MaxLength(250)]
        public virtual string BidURL { get; set; }

        public virtual string Detail { get; set; }

        [MaxLength(250)]
        public virtual string ClientName { get; set; }

        [MaxLength(250)]
        public virtual string ClientEmail { get; set; }

        [MaxLength(250)]
        public virtual string ClientIM { get; set; }

        [MaxLength(250)]
        public virtual string ClientPhone { get; set; }

        public virtual int? ClientCountryId { get; set; }
        [ForeignKey("ClientCountryId")]
        public virtual SalesCountry SalesCountryFK { get; set; }
        public virtual int? CountrysId { get; set; }
        [ForeignKey("CountrysId")]
        public virtual Country CountrysFK { get; set; }
        public virtual int? SalesCurrencyId { get; set; }
        [ForeignKey("SalesCurrencyId")]
        public virtual Currency SalesCurrencyFK { get; set; }
        public virtual int? StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual BidStatus BidStatusFK { get; set; }
        public virtual int? StatusesId { get; set; }
        [ForeignKey("StatusesId")]
        public virtual Status StatusesFK { get; set; }

        public virtual int SourceId { get; set; }
        [ForeignKey("SourceId")]
        public virtual BidSource BidSourceFK { get; set; }

        [Column(TypeName = "decimal(11, 5)")]
        public virtual decimal? Cost { get; set; }

        public virtual string  CoverMessage { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
