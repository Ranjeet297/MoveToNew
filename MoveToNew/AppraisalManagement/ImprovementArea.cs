using Abp.Domain.Entities.Auditing;
using Facile.Governance.AssetTracker;
using MoveToNew.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facile.Governance.AppraisalManagement
{
    public class ImprovementArea: FullAuditedEntity
    {
        public virtual int AppraisalId { get; set; }
        [ForeignKey("AppraisalId")]
        public virtual Appraisal AppraisalIdFk { get; set; }

        [MaxLength(250)]
        public virtual string ImproveArea { get; set; }

        [MaxLength(250)]
        public virtual string ImproveDetail { get; set; }
        [MaxLength(500)]
        public virtual string Feedback { get; set; }
        public virtual int PriorityId { get; set; }
        [ForeignKey("PriorityId")]
        public virtual Priority PriorityIdFk { get; set; }
        public virtual int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual ImprovementAreaStatus StatusIdFk { get; set; }
        public virtual int? StatusesId { get; set; }
        [ForeignKey("StatusesId")]
        public virtual Status StatusesFK { get; set; }
        public virtual DateTimeOffset? EndDate { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }


    }
}
