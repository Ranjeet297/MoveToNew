﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facile.Governance.AppraisalManagement
{
   public class ImprovementAreaStatus: FullAuditedEntity
    {
        [MaxLength(250)]
        public string StatusName { get; set; }

    }
}
