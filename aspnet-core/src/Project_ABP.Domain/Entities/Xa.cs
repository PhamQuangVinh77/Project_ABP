﻿using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Project_ABP.Entities
{
    public class Xa : FullAuditedEntity<Guid>
    {
        public int MaXa { get; set; }
        public string TenXa { get; set; }
        public string Cap { get; set; }
        public int MaTinh { get; set; }
        public int MaHuyen { get; set; }
    }
}
