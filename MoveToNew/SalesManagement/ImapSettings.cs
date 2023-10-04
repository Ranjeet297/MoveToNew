using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facile.Governance.SalesManagement
{
    public class ImapSettings : FullAuditedEntity
    {
        [MaxLength(250)]
        public virtual string IMAP { get; set; }
        [MaxLength(250)]
        public virtual string IMAPUserName { get; set; }
        [MaxLength(250)]
        public virtual string IMAPPassword { get; set; }
    }
}
