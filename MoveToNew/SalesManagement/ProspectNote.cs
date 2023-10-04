using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Facile.Governance.SalesManagement
{
    public class ProspectNote : FullAuditedEntity
    {
        [Required]
        public virtual string Description { get; set; }
        public virtual int ProspectId { get; set; }
        [ForeignKey("ProspectId")]
        public virtual Prospect ProspectFk { get; set; }

    }
}
