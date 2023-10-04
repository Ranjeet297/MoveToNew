
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Facile.Governance.AppraisalManagement;
using Facile.Governance.AssetTracker;
using Facile.Governance.InvoiceManagement;
using MoveToNew.Common;
using MoveToNew.TimesheetManagement;

namespace Facile.Governance.SalesManagement
{
    [Table("Leads")]
    public class Lead : FullAuditedEntity
    {
        [MaxLength(250)]
        [Required]
        public virtual string Name { get; set; }

        [Column(TypeName = "decimal(10,5)")]
        public virtual decimal Amount { get; set; }

        public virtual int CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual Currency CurrencyFk { get; set; }

        public virtual int? ProspectId { get; set; }
        [ForeignKey("ProspectId")]
        public virtual Prospect? ProspectFk { get; set; }


        [Column(TypeName = "decimal(11,5)")]
        public virtual decimal INRAmount { get; set; }
        
        [Column(TypeName = "decimal(11,5)")]
        public virtual decimal? Size { get; set; }

        public virtual string Note { get; set; }

        public virtual DateTimeOffset? LastContacted { get; set; }

        public virtual int SourceId { get; set; }
        [ForeignKey("SourceId")]
        public virtual LeadSource SourceFk { get; set; }

        public virtual int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual LeadStatus StatusFk { get; set; }

        public virtual int? StatusesId { get; set; }
        [ForeignKey("StatusesId")]
        public virtual Status StatusesFK { get; set; }

        public virtual int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual LeadType TypeFK { get; set; }
        public virtual int? TypesId { get; set; }
        [ForeignKey("TypesId")]

        public virtual Facile.Governance.Common.Type TypesFk { get; set; }

        public virtual int? MessageStatusId { get; set; }
        [ForeignKey("MessageStatusId")]
        public virtual LeadMessageStatus MessageStatusFk { get; set; }
        public virtual int? MessageStatusesId { get; set; }
        [ForeignKey("MessageStatusesId")]
        public virtual Status MessageStatusesFk { get; set; }


        [MaxLength(250)]
        public virtual string Comment { get; set; }

        public virtual int PriorityId { get; set; }
        [ForeignKey("PriorityId")]
        public virtual LeadPriority PriorityFk { get; set; }
        public virtual int? PrioritysId { get; set; }
        [ForeignKey("PrioritysId")]
        public virtual Priority PrioritysFk { get; set; }

        public virtual int? LeadStageId { get; set; }
        [ForeignKey("LeadStageId")]
        public virtual LeadStages LeadStageFK { get; set; }

        public virtual int? CompanyServiceId { get; set; }
        [ForeignKey("CompanyServiceId")]
        public virtual CompanyServices CompanyServiceFK { get; set; }

        public virtual long? Owner { get; set; }
        [ForeignKey("Owner")]
        public virtual User OwnerFK { get; set; }
        public virtual DateTimeOffset? TargetCloseDate { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }

    }
}
