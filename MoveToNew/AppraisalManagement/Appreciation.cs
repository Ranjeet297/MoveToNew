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
    public class Appreciation : FullAuditedEntity
    {
        public virtual int AppraisalId { get; set; }
        [ForeignKey("AppraisalId")]
        public virtual Appraisal AppraisalIdFk { get; set; }

        [MaxLength(500)]
        [Required]
        public string AppreciationContent { get; set; }

    }
}
