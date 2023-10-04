using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace Facile.Governance.AssetTracker
{
    public class AssetsSettings : FullAuditedEntity
    {
        [MaxLength(50)]
        public virtual string Prefix { get; set; }

        [MaxLength(50)]
        [Required]
        public virtual string Number { get; set; }

        [MaxLength(50)]
        public virtual string Suffix { get; set; }

    }
}
