using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
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
        private ILogger<XaService> _logger;
        public XaService(IRepository<Xa, Guid> repository, IXaRepository xaRepository, ILogger<XaService> logger) : base(repository)
        {
            _xaRepository = xaRepository;
            _logger = logger;
        }

        public async Task<List<XaDto>> GetAllXas(int maTinh, int maHuyen)
        {
            try
            {
                var responses = await _xaRepository.GetAllXas(maTinh, maHuyen);
                return ObjectMapper.Map<List<Xa>, List<XaDto>>(responses);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
