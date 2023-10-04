using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace Facile.Governance.Costing
{
    public class ChangeReqStatus : FullAuditedEntity
    {
        [MaxLength(50)]
        [Required]
        public virtual string ChangeRequestStatus { get; set; }


    }
}
