using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Facile.Governance.InvoiceManagement
{
    [Table("InvoiceEmailSettings")]
    public class InvoiceEmailSetting: FullAuditedEntity
    {

        [MaxLength(50)]
        public virtual string SMTP { get; set; }

        [MaxLength(50)]
        public virtual string SMTPUser { get; set; }

        [MaxLength(50)]
        public virtual string SMTPPass { get; set; }

        [MaxLength(250)]
        public virtual string FollowUpSubject { get; set; }
        public virtual string FollowUpBody { get; set; }
        public virtual int? FollowUpDay { get; set; }

        [MaxLength(250)]
        public virtual string InvoiceSubject { get; set; }

        public virtual string InvoiceBody { get; set; }
    }
}
