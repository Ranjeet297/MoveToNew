using Abp.Domain.Entities.Auditing;
using Facile.Governance.AssetTracker;
using Facile.Governance.InvoiceManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.SalesManagement
{
    [Table("Prospects")]
    public class Prospect: FullAuditedEntity
    {

        [MaxLength(500)]
        public virtual string  Keywords { get; set; }

        [Required]
        [MaxLength(500)]
        public virtual string  Segments { get; set; }

        public virtual int StatusId { get; set; }  
        [ForeignKey("StatusId")]
        public virtual ProspectStatus ProspectStatusFK { get; set; }

        public virtual int? StatusesId { get; set; }
        [ForeignKey("StatusesId")]
        public virtual Status StatusesFK { get; set; }

        public virtual int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual SalesCountry SalesCountryFK { get; set; }
        public virtual int? CountrysId { get; set; }
        [ForeignKey("CountrysId")]
        public virtual Country CountrysFK { get; set; }

        public virtual string Region { get; set; }     
        
        [MaxLength(250)]
        public virtual string  FirstName { get; set; }

        [MaxLength(250)]
        public virtual string  LastName { get; set; }

        [Required]
        [MaxLength(250)]
        public virtual string  Email { get; set; }

       
        [MaxLength(250)]
        public virtual string  Phone { get; set; }

        [MaxLength(250)]
        public virtual string Company { get; set; }

        [MaxLength(250)]
        public virtual string Address { get; set; }

        [MaxLength(500)]
        public virtual string Detail { get; set; }

        public virtual bool IsActive { get; set; }
        public virtual string Token { get; set; }

        public virtual int? LeadScore { get; set; }

        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
