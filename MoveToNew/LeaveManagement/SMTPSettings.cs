using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace Facile.Governance.LeaveManagement
{
    public class SMTPSettings : FullAuditedEntity
    {
        [MaxLength(250)]
        public virtual string SMTPUrl { get; set; }
        [Required]
        [MaxLength(250)]
        public virtual string UserName { get; set; }
        [Required]
        [MaxLength(250)]
        public virtual string Password { get; set; }
        public virtual int? LeaveToBeAddedYearly { get; set; }
    }
}
