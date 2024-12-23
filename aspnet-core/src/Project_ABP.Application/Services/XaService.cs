using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project_ABP.Dto;
using Project_ABP.Entities;
using Project_ABP.IRepositories;
using Project_ABP.IServices;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Project_ABP.Services
{
    public class XaService : CrudAppService<Xa, XaDto, Guid, PagedAndSortedResultRequestDto, CreateOrUpdateXaDto, CreateOrUpdateXaDto>, IXaService
    {
        private readonly IXaRepository _xaRepository;
        public XaService(IRepository<Xa, Guid> repository, IXaRepository xaRepository) : base(repository)
        {
            _xaRepository = xaRepository;
        }

        public async Task<List<XaDto>> GetAllXas(int maTinh, int maHuyen)
        {
            var responses = await _xaRepository.GetAllXas(maTinh, maHuyen);
            return ObjectMapper.Map<List<Xa>, List<XaDto>>(responses);
        }
    }
}
