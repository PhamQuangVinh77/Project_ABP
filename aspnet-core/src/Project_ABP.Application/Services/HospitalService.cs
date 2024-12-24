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
    public class HospitalService : CrudAppService<Hospital, HospitalDto, int, PagedAndSortedResultRequestDto, CreateOrUpdateHospitalDto, CreateOrUpdateHospitalDto>, IHospitalService
    {
        private readonly IHospitalRepository _hospitalRepository;
        private ILogger<HospitalService> _logger;
        public HospitalService(IRepository<Hospital, int> repository, IHospitalRepository hospitalRepository, ILogger<HospitalService> logger) : base(repository)
        {
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
    }
}
