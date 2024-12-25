using Volo.Abp.Application.Dtos;

namespace Project_ABP.Dto.HuyenDtos
{
    public class HuyenPagedAndSortedResultRequestDto : PagedAndSortedResultRequestDto
    {
        public int? MaTinh { get; set; } = 0;
        public string? Filter { get; set; } = "";
    }
}
