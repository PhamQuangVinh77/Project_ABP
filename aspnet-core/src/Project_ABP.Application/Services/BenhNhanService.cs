using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Project_ABP.Dto.BenhNhanDtos;
using Project_ABP.Entities;
using Project_ABP.Filter;
using Project_ABP.IRepositories;
using Project_ABP.IServices;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Project_ABP.Services
{
    public class BenhNhanService : CrudAppService<BenhNhan, BenhNhanDto, int, BenhNhanPagedAndSortedResultRequestDto, CreateOrUpdateBenhNhanDto, CreateOrUpdateBenhNhanDto>, IBenhNhanService
    {
        private readonly IBenhNhanRepository _benhNhanRepository;
        private readonly IUserHospitalRepository _userHospitalRepository;
        private ILogger<BenhNhanService> _logger;
        public BenhNhanService(IRepository<BenhNhan, int> repository, IBenhNhanRepository benhNhanRepository, IUserHospitalRepository userHospitalRepository, ILogger<BenhNhanService> logger) : base(repository)
        {
            _benhNhanRepository = benhNhanRepository;
            _userHospitalRepository = userHospitalRepository;
            _logger = logger;
        }

        public async Task<List<BenhNhanDto>> GetAllBenhNhans()
        {
            try
            {
                var hospitalId = await GetHospitalIdByCurrentUser();
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
                filter.HospitalId = await GetHospitalIdByCurrentUser();
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

        public override async Task<BenhNhanDto> CreateAsync(CreateOrUpdateBenhNhanDto input)
        {
            try
            {
                input.Ma = GeneratedCode(6);
                input.HospitalId = await GetHospitalIdByCurrentUser();
                // Gọi phương thức tạo mặc định (base)
                var benhNhan = await base.CreateAsync(input);
                return benhNhan;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        private async Task<int> GetHospitalIdByCurrentUser()
        {
            return await _userHospitalRepository.GetHospitalIdByCurrentUser();
        }

        private string GeneratedCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                                        .Select(s => s[random.Next(s.Length)])
                                        .ToArray());
        }
    }
}
