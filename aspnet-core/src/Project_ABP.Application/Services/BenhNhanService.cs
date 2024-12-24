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
    public class BenhNhanService : CrudAppService<BenhNhan, BenhNhanDto, int, PagedAndSortedResultRequestDto, CreateOrUpdateBenhNhanDto, CreateOrUpdateBenhNhanDto>, IBenhNhanService
    {
        private readonly IBenhNhanRepository _benhNhanRepository;
        private ILogger<BenhNhanService> _logger;
        public BenhNhanService(IRepository<BenhNhan, int> repository, IBenhNhanRepository benhNhanRepository, ILogger<BenhNhanService> logger) : base(repository)
        {
            _benhNhanRepository = benhNhanRepository;
            _logger = logger;
        }

        public async Task<List<BenhNhanDto>> GetAllBenhNhan(int hospitalId)
        {
            try
            {
                var responses = await _benhNhanRepository.GetAllBenhNhans(hospitalId);
                return ObjectMapper.Map<List<BenhNhan>, List<BenhNhanDto>>(responses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
