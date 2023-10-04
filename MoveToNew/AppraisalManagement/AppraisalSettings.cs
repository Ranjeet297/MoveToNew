using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facile.Governance.AppraisalManagement
{
    public class AppraisalSettings: FullAuditedEntity
    {
        [MaxLength(250)]
        public virtual string SMTPUrl { get; set; }
        [MaxLength(250)]
        public virtual string SMTPUserName { get; set; }
        [MaxLength(250)]
        public virtual string SMTPPassword { get; set; }
    }
}
