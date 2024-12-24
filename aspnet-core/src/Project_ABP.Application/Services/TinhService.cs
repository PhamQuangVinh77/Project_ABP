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
    public class TinhService : CrudAppService<Tinh, TinhDto, Guid, PagedAndSortedResultRequestDto, CreateOrUpdateTinhDto, CreateOrUpdateTinhDto>, ITinhService
    {
        private readonly ITinhRepository _tinhRepository;
        private ILogger<TinhService> _logger;
        public TinhService(IRepository<Tinh, Guid> repository, ITinhRepository tinhRepository, ILogger<TinhService> logger) : base(repository)
        {
            _tinhRepository = tinhRepository;
            _logger = logger;
        }        
        
        public async Task<List<TinhDto>> GetAllTinhs()
        {
            try
            {
                var responses = await _tinhRepository.GetAllTinhs();
                return ObjectMapper.Map<List<Tinh>, List<TinhDto>>(responses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
