using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Facile.Governance.SalesManagement
{
    public class ProspectCalls : FullAuditedEntity
    {
        [Required]
        public virtual string Description { get; set; }
        public virtual DateTimeOffset? Date { get; set; }
        public virtual DateTimeOffset? Time { get; set; }
        public virtual int ProspectId { get; set; }
        [ForeignKey("ProspectId")]
        public virtual Prospect ProspectFk { get; set; }


        public virtual int CallTypeId { get; set; }
        [ForeignKey("CallTypeId")]
        public virtual CallType CallTypeIdFK { get; set; }
        public virtual int? TypesId { get; set; }
        [ForeignKey("TypesId")]

        public virtual Facile.Governance.Common.Type TypesFk { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }

    }
}
