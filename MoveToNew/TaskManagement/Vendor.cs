using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.TaskManagement
{
    [Table("Vendors")]
    public class Vendor: FullAuditedEntity
    {
        [MaxLength(250)]
        public virtual string FirstName { get; set; }
        [MaxLength(250)]
        public virtual string LastName { get; set; }
        [MaxLength(250)]
        public virtual string DisplayName { get; set; }
        [MaxLength(250)]
        public virtual string EmailAddress { get; set; }
        [MaxLength(250)]
        public virtual string Company { get; set; }
    }
}
