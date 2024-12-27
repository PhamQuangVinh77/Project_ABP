using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Project_ABP.Dto.XaDtos;
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
    public class XaService : CrudAppService<Xa, XaDto, Guid, XaPagedAndSortedResultRequestDto, CreateOrUpdateXaDto, CreateOrUpdateXaDto>, IXaService
    {
        private readonly IXaRepository _xaRepository;
        private ILogger<XaService> _logger;
        public XaService(IRepository<Xa, Guid> repository, IXaRepository xaRepository, ILogger<XaService> logger) : base(repository)
        {
            GetPolicyName = Project_ABPPermissions.XaPermissions.Default;
            GetListPolicyName = Project_ABPPermissions.XaPermissions.Default;
            CreatePolicyName = Project_ABPPermissions.XaPermissions.Create;
            UpdatePolicyName = Project_ABPPermissions.XaPermissions.Edit;
            DeletePolicyName = Project_ABPPermissions.XaPermissions.Delete;

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

        public override async Task<PagedResultDto<XaDto>> GetListAsync(XaPagedAndSortedResultRequestDto request)
        {
            try
            {
                var filter = ObjectMapper.Map<XaPagedAndSortedResultRequestDto, XaFilter>(request);
                var sorting = string.IsNullOrEmpty(request.Sorting) ? "maXa ASC" : request.Sorting;
                var response = await _xaRepository.GetListAsync(request.SkipCount, request.MaxResultCount, sorting, filter);
                var totalCount = await _xaRepository.GetTotalCountAsync(filter);
                return new PagedResultDto<XaDto>(totalCount, ObjectMapper.Map<List<Xa>, List<XaDto>>(response));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
