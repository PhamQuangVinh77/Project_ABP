using System.Collections.Generic;
using System.Threading.Tasks;
using Project_ABP.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Project_ABP.IServices
{
    public interface IBenhNhanService : ICrudAppService<BenhNhanDto, int, PagedAndSortedResultRequestDto, CreateOrUpdateBenhNhanDto, CreateOrUpdateBenhNhanDto>
    {
        Task<List<BenhNhanDto>> GetAllBenhNhan(int hospitalId);
    }
}
