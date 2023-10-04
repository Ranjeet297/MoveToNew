using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.SalesManagement
{
    [Table("ProspectSegments")]
    public class ProspectSegments: FullAuditedEntity
    {
        [MaxLength(250)]
        [Required]
        public virtual string Name { get; set; }
    }
}
