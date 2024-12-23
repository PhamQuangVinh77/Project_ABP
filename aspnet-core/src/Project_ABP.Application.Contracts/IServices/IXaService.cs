using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project_ABP.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Project_ABP.IServices
{
    public interface IXaService : ICrudAppService<XaDto, Guid, PagedAndSortedResultRequestDto, CreateOrUpdateXaDto, CreateOrUpdateXaDto>
    {
        Task<List<XaDto>> GetAllXas(int maTinh, int maHuyen);
    }
}
