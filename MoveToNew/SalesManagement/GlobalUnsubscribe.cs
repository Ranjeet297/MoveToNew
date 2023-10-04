using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.SalesManagement
{
    [Table("GlobalUnsubscribe")]
    public class GlobalUnsubscribe : FullAuditedEntity
    {
        public virtual string Email { get; set; }
    }
}
