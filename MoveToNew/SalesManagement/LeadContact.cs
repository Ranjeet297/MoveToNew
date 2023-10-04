using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.SalesManagement
{
    [Table("LeadContacts")]
    public class LeadContact : FullAuditedEntity
    {
        [MaxLength(250)]
        public virtual string FristName { get; set; }
        [MaxLength(250)]
        public virtual string LastName { get; set; }
        [Required]
        [MaxLength(250)]
        public virtual string Email { get; set; }
        [MaxLength(250)]
        public virtual string Phone { get; set; }        
        public virtual int LeadId { get; set; }
        [ForeignKey("LeadId")]
        public virtual Lead LeadFK { get; set; }
    }
}
