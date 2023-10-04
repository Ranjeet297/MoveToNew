using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.TaskManagement
{
    [Table("ReminderEmails")]
    public class ReminderEmail : FullAuditedEntity
    {
        
        public string ReminderAfterInternelSubject { get; set; }
        
        public string ReminderBeforeInternelSubject { get; set; }
        
        public string ReminderAfterExternelSubject { get; set; }
        
        public string ReminderBeforeExternelSubject { get; set; }
        
        public string ReminderAfterInternelEmail { get; set; }
        
        public string ReminderBeforeInternelEmail { get; set; }
        
        public string ReminderAfterExternelEmail { get; set; }
        
        public string ReminderBeforeExternelEmail { get; set; }

    }
}
