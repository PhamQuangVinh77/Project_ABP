using System.Collections.Generic;
using System.Threading.Tasks;
using Project_ABP.Dto.BenhNhanDtos;
using Volo.Abp.Application.Services;

namespace Project_ABP.IServices
{
    public interface IBenhNhanService : ICrudAppService<BenhNhanDto, int, BenhNhanPagedAndSortedResultRequestDto, CreateOrUpdateBenhNhanDto, CreateOrUpdateBenhNhanDto>
    {
        Task<List<BenhNhanDto>> GetAllBenhNhans();
        Task<string> GetHospitalNameByCurrentUser();
    }
}
