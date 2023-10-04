using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace Facile.Governance.SalesManagement
{
    public class Mailsender : FullAuditedEntity
    {
        [MaxLength(250)]
        [Required]
        public virtual string Name { get; set; }

        [Required]

        public virtual string Type { get; set; }  
        public virtual string Server { get; set; }

        public virtual string UserName { get; set;}

        [Required]
        public virtual string Password { get; set; }
        [Required]
        public virtual bool IsActive { get; set; }

        
    }
}
