using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;


namespace Facile.Governance.InvoiceManagement
{
    public class ProjectTax : FullAuditedEntity
    {
        public virtual int TaxId { get; set; }
        [ForeignKey("TaxId")]
        public virtual Tax TaxFK { get; set; }

        public virtual int? ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project ProjectFK { get; set; }

        public bool IsActive { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }

    }
}
