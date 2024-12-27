using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Project_ABP.Dto.TinhDto;
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
    public class TinhService : CrudAppService<Tinh, TinhDto, Guid, TinhPagedAndSortedResultRequestDto, CreateOrUpdateTinhDto, CreateOrUpdateTinhDto>, ITinhService
    {
        private readonly ITinhRepository _tinhRepository;
        private ILogger<TinhService> _logger;
        public TinhService(IRepository<Tinh, Guid> repository, ITinhRepository tinhRepository, ILogger<TinhService> logger) : base(repository)
        {
            GetPolicyName = Project_ABPPermissions.TinhPermissions.Default;
            GetListPolicyName = Project_ABPPermissions.TinhPermissions.Default;
            CreatePolicyName = Project_ABPPermissions.TinhPermissions.Create;
            UpdatePolicyName = Project_ABPPermissions.TinhPermissions.Edit;
            DeletePolicyName = Project_ABPPermissions.TinhPermissions.Delete;

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

        public override async Task<PagedResultDto<TinhDto>> GetListAsync(TinhPagedAndSortedResultRequestDto request)
        {
            try
            {
                var filter = ObjectMapper.Map<TinhPagedAndSortedResultRequestDto, TinhFilter>(request);
                var sorting = string.IsNullOrEmpty(request.Sorting) ? "maTinh ASC" : request.Sorting;
                var response = await _tinhRepository.GetListAsync(request.SkipCount, request.MaxResultCount, sorting, filter);
                var totalCount = await _tinhRepository.GetTotalCountAsync(filter);
                return new PagedResultDto<TinhDto>(totalCount, ObjectMapper.Map<List<Tinh>, List<TinhDto>>(response));
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
