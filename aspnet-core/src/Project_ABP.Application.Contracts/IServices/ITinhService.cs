using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project_ABP.Dto.TinhDto;
using Volo.Abp.Application.Services;

namespace Project_ABP.IServices
{
    public interface ITinhService : ICrudAppService<TinhDto, Guid, TinhPagedAndSortedResultRequestDto, CreateOrUpdateTinhDto, CreateOrUpdateTinhDto>
    {
        Task<List<TinhDto>> GetAllTinhs();
    }
}
