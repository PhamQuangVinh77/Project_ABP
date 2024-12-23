using System;
using Volo.Abp.Application.Dtos;

namespace Project_ABP.Dto
{
    public class XaDto : FullAuditedEntityDto<Guid>
    {
        public int MaXa { get; set; }
        public string TenXa { get; set; }
        public string Cap { get; set; }
        public int MaTinh { get; set; }
        public int MaHuyen { get; set; }
    }
}
