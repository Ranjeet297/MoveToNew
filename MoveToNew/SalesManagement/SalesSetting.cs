using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.SalesManagement
{
    [Table("SalesSettings")]
    public class SalesSetting: FullAuditedEntity
    {
        [MaxLength(250)]
        public virtual string SMTP { get; set; }
        [MaxLength(250)]
        public virtual string SMTPUser { get; set; }
        [MaxLength(250)]
        public virtual string SMTPPass { get; set; }

        public virtual int ClickCount { get; set; }

        public virtual int OpenedCount { get; set; }
    }
}
