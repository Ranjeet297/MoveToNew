using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace Facile.Governance.Costing
{
    public class Trackingtask : FullAuditedEntity
    {
        [Required]
        [MaxLength(50)]
        public virtual string TrackingType { get; set; }
    }
}
