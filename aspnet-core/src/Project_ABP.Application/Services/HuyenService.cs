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
    public class HuyenService : CrudAppService<Huyen, HuyenDto, Guid, PagedAndSortedResultRequestDto, CreateOrUpdateHuyenDto, CreateOrUpdateHuyenDto>, IHuyenService
    {
        private readonly IHuyenRepository _huyenRepository;
        private ILogger<HuyenService> _logger;
        public HuyenService(IRepository<Huyen, Guid> repository, IHuyenRepository huyenRepository, ILogger<HuyenService> logger) : base(repository)
        {
            _huyenRepository = huyenRepository;
            _logger = logger;
        }

        public async Task<List<HuyenDto>> GetAllHuyens(int maTinh)
        {
            try
            {
                var response = await _huyenRepository.GetAllHuyens(maTinh);
                return ObjectMapper.Map<List<Huyen>, List<HuyenDto>>(response);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
