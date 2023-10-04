using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.TaskManagement
{
    [Table("SmtpSettings")] 
    public class SmtpSettings : FullAuditedEntity
    {
        [MaxLength(500)]
        public virtual string Server { get; set; }
        [MaxLength(500)]
        public virtual string User { get; set; }
        [MaxLength(500)]
        public virtual string Password { get; set; }
    }
}
