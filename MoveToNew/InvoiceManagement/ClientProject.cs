using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Facile.Governance.InvoiceManagement
{
    [Table("ClientProjects")]
    public class ClientProject : FullAuditedEntity
    {
        public virtual int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client ClientFK { get; set; }

        public virtual int? ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project ProjectFK { get; set; }

        public virtual int CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual Currency CurrencyFK { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public virtual decimal? Hours { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public virtual decimal? MonthlyHours { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public virtual decimal? Amount { get; set; }

        public virtual string ContactName { get; set; }
        public virtual string ContactEmail { get; set; }
        public virtual bool IsActive { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
