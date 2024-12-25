using System;
using Volo.Abp.Application.Dtos;

namespace Project_ABP.Dto.HuyenDtos
{
    public class HuyenDto : FullAuditedEntityDto<Guid>
    {
        public int MaHuyen { get; set; }
        public string TenHuyen { get; set; }
        public string Cap { get; set; }
        public int MaTinh { get; set; }
    }
}
