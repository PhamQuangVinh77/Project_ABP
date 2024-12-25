using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project_ABP.Dto.XaDtos;
using Volo.Abp.Application.Services;

namespace Project_ABP.IServices
{
    public interface IXaService : ICrudAppService<XaDto, Guid, XaPagedAndSortedResultRequestDto, CreateOrUpdateXaDto, CreateOrUpdateXaDto>
    {
        Task<List<XaDto>> GetAllXas(int maTinh, int maHuyen);
    }
}
