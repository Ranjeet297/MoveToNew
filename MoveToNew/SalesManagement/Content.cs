using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Facile.Governance.AssetTracker;
using MoveToNew.TimesheetManagement;

namespace Facile.Governance.SalesManagement
{
    [Table("Contents")]
    public class Content: FullAuditedEntity
    {
        [MaxLength(250)]
        [Required]
        public virtual string Name { get; set; }

        [MaxLength(500)]
        public virtual string Detail { get; set; }
       

        [MaxLength(500)]
        public virtual string Keyword { get; set; }
        
        public virtual string Link { get; set; }

        public virtual int Status { get; set; }
        [ForeignKey("Status")]
        public virtual ContentStatus ContentStatusFK { get; set; }

        public virtual int? StatusesId { get; set; }
        [ForeignKey("StatusesId")]
        public virtual Status StatusesFK { get; set; }


        public virtual long AssignTo { get; set; }
        [ForeignKey("AssignTo")]
        public virtual User UserFK { get; set; }


        public virtual DateTimeOffset? PlanPublishDate { get; set; }
        public virtual DateTimeOffset? PublishDate { get; set; }
        public virtual DateTimeOffset? SocialPublishDate { get; set; }
        public virtual bool IsActive { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
