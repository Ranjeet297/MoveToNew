﻿using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facile.Governance.SalesManagement
{
    [Table("SalesTargetTypes")]
    public class SalesTargetType: FullAuditedEntity
    {
        [MaxLength(250)]
        [Required]
        public virtual string  Name { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        [Column(TypeName = "timestamp without time zone")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
    }
}
