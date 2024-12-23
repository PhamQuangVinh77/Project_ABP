using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project_ABP.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Project_ABP.IServices
{
    public interface IHuyenService : ICrudAppService<HuyenDto, Guid, PagedAndSortedResultRequestDto, CreateOrUpdateHuyenDto, CreateOrUpdateHuyenDto>
    {
        Task<List<HuyenDto>> GetAllHuyens(int maTinh);
    }
}
