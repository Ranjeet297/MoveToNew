using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace Facile.Governance.Costing
{
    public class BudgetSet : FullAuditedEntity
    {
        [Required]
        [MaxLength(50)]
        public virtual string BudgetSettings { get; set; }
    }
}
