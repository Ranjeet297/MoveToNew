using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Facile.Governance.AppraisalManagement
{
    public class EmployeeSkills : FullAuditedEntity
    {
        public virtual int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee EmployeeIdFk { get; set; }
        public virtual int SkillId { get; set; }
        [ForeignKey("SkillId")]
        public virtual Skills SkillIdFk { get; set; }


    }
}
