using Abp.Domain.Entities.Auditing;
using Facile.Governance.AssetTracker;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facile.Governance.AppraisalManagement
{
   public class Action : FullAuditedEntity
    {
        public virtual int ImprovementAreaId { get; set; }
        [ForeignKey("ImprovementAreaId")]
        public virtual ImprovementArea ImprovementAreaIdFk { get; set; }

        [MaxLength(250)]
        public virtual string ActionName { get; set; }

        [MaxLength(500)]
        public virtual string ActionDetail { get; set; }
        public virtual int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual ActionStatus StatusIdFk { get; set; }

        public virtual int? StatusesId { get; set; }
        [ForeignKey("StatusesId")]
        public virtual Status StatusesFK { get; set; }

        [MaxLength(250)]
        public virtual string ActionTaken{ get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }

    }
}
