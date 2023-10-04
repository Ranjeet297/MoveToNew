using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Facile.Governance.SalesManagement
{
    [Table("SalesMailSettings")]
    public class SalesMailSetting : FullAuditedEntity
    {
        [MaxLength(250)]
        public virtual string SMTP{ get; set; }
        [MaxLength(250)]
        public virtual string SMTPUser { get; set; }
        [MaxLength(250)]
        public virtual string SMTPPassword { get; set; }
    }
}
