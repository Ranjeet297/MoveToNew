using Abp.Domain.Entities.Auditing;
using Facile.Governance.InvoiceManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.SalesManagement
{
    [Table("SalesRegions")]
   public class SalesRegion : FullAuditedEntity
    {
        [MaxLength(250)]
        [Required]
        public virtual string Name { get; set; }
        public virtual int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual SalesCountry countryFK { get; set; }
        public virtual int? CountrysId { get; set; }
        [ForeignKey("CountrysId")]
        public virtual Country CountrysFK { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
