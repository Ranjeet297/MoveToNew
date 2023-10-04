using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facile.Governance.AppraisalManagement
{
    public class AssignManager: FullAuditedEntity
    {
        public virtual int ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public virtual Employee ManagerIdFk { get; set; }
        public virtual int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee EmployeeIdFk { get; set; }
    }
}
