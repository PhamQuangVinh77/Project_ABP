using System;
using Volo.Abp.Application.Dtos;

namespace Project_ABP.Dto.TinhDto
{
    public class TinhDto : FullAuditedEntityDto<Guid>
    {
        public int MaTinh { get; set; }
        public string TenTinh { get; set; }
        public string Cap { get; set; }
    }
}
