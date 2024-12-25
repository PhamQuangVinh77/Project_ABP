using Volo.Abp.Application.Dtos;

namespace Project_ABP.Dto.HospitalDtos
{
    public class HospitalPagedAndSortedResultRequestDto : PagedAndSortedResultRequestDto
    {
        public int? MaTinh { get; set; } = 0;
        public int? MaHuyen { get; set; } = 0;
        public int? MaXa { get; set; } = 0;
        public string? Filter { get; set; } = "";
    }
}
