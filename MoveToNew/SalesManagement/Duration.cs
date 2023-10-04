using Abp.Domain.Entities.Auditing;

namespace Facile.Governance.SalesManagement
{
    public class Duration : FullAuditedEntity
    {
        public string DurationTime { get; set; }
    }
}
