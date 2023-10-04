using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace Facile.Governance.LeaveManagement
{
    public class SalarySettings : FullAuditedEntity
    {
        [Required]
        [MaxLength(50)]
        public virtual string SalarySetting { get; set; }
    }

}
