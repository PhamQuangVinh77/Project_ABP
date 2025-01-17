﻿using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Project_ABP.Entities
{
    public class Tinh : FullAuditedEntity<Guid>
    {
        public int MaTinh { get; set; }
        public string TenTinh { get; set; }
        public string Cap { get; set; }
    }
}
