using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Project_ABP.Dto.ExcelDtos;
using Project_ABP.Dto.HuyenDtos;
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
    public class HuyenService : CrudAppService<Huyen, HuyenDto, Guid, HuyenPagedAndSortedResultRequestDto, CreateOrUpdateHuyenDto, CreateOrUpdateHuyenDto>, IHuyenService
    {
        private readonly IMapper _mapper;
        private readonly IHuyenRepository _huyenRepository;
        private ILogger<HuyenService> _logger;
        public HuyenService(IMapper mapper, IRepository<Huyen, Guid> repository, IHuyenRepository huyenRepository, ILogger<HuyenService> logger) : base(repository)
        {
            GetPolicyName = Project_ABPPermissions.HuyenPermissions.Default;
            GetListPolicyName = Project_ABPPermissions.HuyenPermissions.Default;
            CreatePolicyName = Project_ABPPermissions.HuyenPermissions.Create;
            UpdatePolicyName = Project_ABPPermissions.HuyenPermissions.Edit;
            DeletePolicyName = Project_ABPPermissions.HuyenPermissions.Delete;

            _mapper = mapper;
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

        public override async Task<PagedResultDto<HuyenDto>> GetListAsync(HuyenPagedAndSortedResultRequestDto request)
        {
            try
            {
                var filter = ObjectMapper.Map<HuyenPagedAndSortedResultRequestDto, HuyenFilter>(request);
                var sorting = string.IsNullOrEmpty(request.Sorting) ? "maHuyen ASC" : request.Sorting;
                var response = await _huyenRepository.GetListAsync(request.SkipCount, request.MaxResultCount, sorting, filter);
                var totalCount = await _huyenRepository.GetTotalCountAsync(filter);
                return new PagedResultDto<HuyenDto>(totalCount, ObjectMapper.Map<List<Huyen>, List<HuyenDto>>(response));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task ImportExcel(List<HuyenDto> listHuyen)
        {
            try
            {
                var file = new FileInfo(@"C:\Users\Admin\Documents\Projects\ABP_Framework\excel\danh-sach-huyen.xlsx");
                var listDataExcel = _mapper.Map<List<ExcelDto>>(listHuyen);
                var sheetName = "danh-sach-huyen";
                var title = "Danh sách huyện";
                await ExcelService.CreateExcelFile(file, listDataExcel, sheetName, title);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

        }
    }
}
