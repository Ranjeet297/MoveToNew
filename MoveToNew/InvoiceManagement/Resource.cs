using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.InvoiceManagement
{
    [Table("Resources")]
    public class Resource : FullAuditedEntity
    {
        [MaxLength(50)]
        public virtual string Name { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
