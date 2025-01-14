﻿using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Project_ABP.Entities
{
    public class Huyen : FullAuditedEntity<Guid>
    {
        public int MaHuyen { get; set; }
        public string TenHuyen { get; set; }
        public string Cap { get; set; }
        public int MaTinh { get; set; }
    }
}
