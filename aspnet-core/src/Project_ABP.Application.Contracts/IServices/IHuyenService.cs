using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project_ABP.Dto.HuyenDtos;
using Volo.Abp.Application.Services;

namespace Project_ABP.IServices
{
    public interface IHuyenService : ICrudAppService<HuyenDto, Guid, HuyenPagedAndSortedResultRequestDto, CreateOrUpdateHuyenDto, CreateOrUpdateHuyenDto>
    {
        Task<List<HuyenDto>> GetAllHuyens(int maTinh);
        Task ExportExcel(List<HuyenDto> listHuyen);
    }
}
