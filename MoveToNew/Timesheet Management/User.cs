using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace MoveToNew.TimesheetManagement
{
    public class User: FullAuditedEntity
    {
        [Required]
        public virtual long? Id { get; set; }
        [Required]
        [StringLength(64)]
        public virtual string Name { get; set; }
        [Required]
        [StringLength(64)]
        public virtual string Surname { get; set; }
        [Required]
        [StringLength(256)]
        public virtual string UserName { get; set; }
        [Required]
        [StringLength(128)]
        public virtual string Password { get; set; }

        [Required]
        [StringLength(128)]
        public virtual string ConfirmPassword { get; set; }
        [Required]
        [StringLength(256)]
        public virtual string EmailAddress { get; set; }

        public virtual bool IsActive { get; set; }
    }
}
