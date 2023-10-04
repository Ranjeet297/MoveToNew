using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace Facile.Governance.SalesManagement
{
    public class MailBoxes : FullAuditedEntity
    {
        [MaxLength(250)]
        public virtual string Name { get; set; }
        [MaxLength(250)]
        public virtual string UserName { get; set; }
        [MaxLength(250)]
        public virtual string Password { get; set; }
        [MaxLength(250)]
        public virtual string SMTPServer { get; set; }
        [MaxLength(250)]
        public virtual string IMAPServer { get; set; }
    }
}
