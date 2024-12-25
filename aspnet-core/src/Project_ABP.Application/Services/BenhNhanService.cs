using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Project_ABP.Dto.BenhNhanDtos;
using Project_ABP.Entities;
using Project_ABP.Filter;
using Project_ABP.IRepositories;
using Project_ABP.IServices;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Project_ABP.Services
{
    public class BenhNhanService : CrudAppService<BenhNhan, BenhNhanDto, int, BenhNhanPagedAndSortedResultRequestDto, CreateOrUpdateBenhNhanDto, CreateOrUpdateBenhNhanDto>, IBenhNhanService
    {
        private readonly IBenhNhanRepository _benhNhanRepository;
        private ILogger<BenhNhanService> _logger;
        public BenhNhanService(IRepository<BenhNhan, int> repository, IBenhNhanRepository benhNhanRepository, ILogger<BenhNhanService> logger) : base(repository)
        {
            _benhNhanRepository = benhNhanRepository;
            _logger = logger;
        }

        public async Task<List<BenhNhanDto>> GetAllBenhNhans(int hospitalId)
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

        public override async Task<PagedResultDto<BenhNhanDto>> GetListAsync(BenhNhanPagedAndSortedResultRequestDto request)
        {
            try
            {
                var filter = ObjectMapper.Map<BenhNhanPagedAndSortedResultRequestDto, BenhNhanFilter>(request);
                var sorting = string.IsNullOrEmpty(request.Sorting) ? "ma ASC" : request.Sorting;
                var response = await _benhNhanRepository.GetListAsync(request.SkipCount, request.MaxResultCount, sorting, filter);
                var totalCount = await _benhNhanRepository.GetTotalCountAsync(filter);
                return new PagedResultDto<BenhNhanDto>(totalCount, ObjectMapper.Map<List<BenhNhan>, List<BenhNhanDto>>(response));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
