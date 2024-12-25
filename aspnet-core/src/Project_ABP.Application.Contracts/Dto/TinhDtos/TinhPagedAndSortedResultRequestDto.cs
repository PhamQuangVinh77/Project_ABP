using Volo.Abp.Application.Dtos;

namespace Project_ABP.Dto.TinhDto
{
    public class TinhPagedAndSortedResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; } = "";
    }
}
