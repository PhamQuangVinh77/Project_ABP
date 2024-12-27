using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Project_ABP.Dto.HospitalDtos;
using Project_ABP.Entities;
using Project_ABP.Filter;
using Project_ABP.IRepositories;
using Project_ABP.IServices;
using Project_ABP.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Project_ABP.Services
{
    public class HospitalService : CrudAppService<Hospital, HospitalDto, int, HospitalPagedAndSortedResultRequestDto, CreateOrUpdateHospitalDto, CreateOrUpdateHospitalDto>, IHospitalService
    {
        private readonly IHospitalRepository _hospitalRepository;
        private ILogger<HospitalService> _logger;
        public HospitalService(IRepository<Hospital, int> repository, IHospitalRepository hospitalRepository, ILogger<HospitalService> logger) : base(repository)
        {
            CreatePolicyName = Project_ABPPermissions.HospitalPermissions.Create;
            UpdatePolicyName = Project_ABPPermissions.HospitalPermissions.Edit;
            DeletePolicyName = Project_ABPPermissions.HospitalPermissions.Delete;

            _hospitalRepository = hospitalRepository;
            _logger = logger;
        }

        public async Task<List<HospitalDto>> GetAllHospitals(int maTinh, int maHuyen, int maXa)
        {
            try
            {
                var responses = await _hospitalRepository.GetAllHospitals(maTinh, maHuyen, maXa);
                return ObjectMapper.Map<List<Hospital>, List<HospitalDto>>(responses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public override async Task<PagedResultDto<HospitalDto>> GetListAsync(HospitalPagedAndSortedResultRequestDto request)
        {
            try
            {
                var filter = ObjectMapper.Map<HospitalPagedAndSortedResultRequestDto, HospitalFilter>(request);
                var sorting = string.IsNullOrEmpty(request.Sorting) ? "ma ASC" : request.Sorting;
                var response = await _hospitalRepository.GetListAsync(request.SkipCount, request.MaxResultCount, sorting, filter);
                var totalCount = await _hospitalRepository.GetTotalCountAsync(filter);
                return new PagedResultDto<HospitalDto>(totalCount, ObjectMapper.Map<List<Hospital>, List<HospitalDto>>(response));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
