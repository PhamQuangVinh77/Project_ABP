using Volo.Abp.Application.Dtos;

namespace Project_ABP.Dto.BenhNhanDtos
{
    public class BenhNhanPagedAndSortedResultRequestDto : PagedAndSortedResultRequestDto
    {
        public int? HospitalId { get; set; } = 0;
        public string? Filter { get; set; } = "";
    }
}
