using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace Facile.Governance.AssetTracker
{
    public class Brand : FullAuditedEntity
    {
        [MaxLength(250)]
        [Required]
        public virtual string Name { get; set; }
        public virtual bool IsActive { get; set; }

    }
}
