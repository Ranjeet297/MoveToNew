using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facile.Governance.InvoiceManagement
{
   public  class CreditDetail : FullAuditedEntity
    {
        [MaxLength(250)]
        public virtual string Description { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public virtual decimal Rate { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public virtual decimal Qty { get; set; }

        public virtual int CreditNoteId { get; set; }
        [ForeignKey("CreditNoteId")]
        public CreditNote CreditNoteFk { get; set; }
    }
}
