using System.Collections.Generic;
using System.Threading.Tasks;
using Project_ABP.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Project_ABP.IServices
{
    public interface IHospitalService : ICrudAppService<HospitalDto, int, PagedAndSortedResultRequestDto, CreateOrUpdateHospitalDto, CreateOrUpdateHospitalDto>
    {
        Task<List<HospitalDto>> GetAllHospitals(int maTinh, int maHuyen, int maXa);
    }
}
