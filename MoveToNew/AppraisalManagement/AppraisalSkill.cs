using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facile.Governance.AppraisalManagement
{
   public class AppraisalSkill: FullAuditedEntity
    {
        public virtual int AppraisalId { get; set; }
        [ForeignKey("AppraisalId")]
        public virtual Appraisal AppraisalIdFk { get; set; }
        public virtual int EmployeeSkillId { get; set; }
        [ForeignKey("EmployeeSkillId")]
        public virtual EmployeeSkills EmployeeSkillsIdFk { get; set; }

        [MaxLength(500)]
        public virtual string Comments { get; set; }
        public virtual int Marks { get; set; }
    }
}
