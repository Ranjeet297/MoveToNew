using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Facile.Governance.InvoiceManagement
{
    [Table ("CompanySettings")]
    public class CompanySetting: FullAuditedEntity
    {
        [MaxLength(50)]
        public virtual string Name { get; set; }

        [MaxLength(250)]
        public virtual string Company { get; set; }

        public virtual string Address { get; set; }

        public virtual int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country CountryFK { get; set; }

        [MaxLength(50)]
        public virtual string Phone { get; set; }

        [MaxLength(50)]
        public virtual string Email { get; set; }

        [MaxLength(50)]
        public virtual string PanNo { get; set; }

        [MaxLength(50)]
        public virtual string GSTNo { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
