using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Project_ABP.Dto.ExcelDtos;
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
        private readonly IMapper _mapper;
        private readonly ITinhRepository _tinhRepository;
        private ILogger<TinhService> _logger;
        public TinhService(IMapper mapper, IRepository<Tinh, Guid> repository, ITinhRepository tinhRepository, ILogger<TinhService> logger) : base(repository)
        {
            GetPolicyName = Project_ABPPermissions.TinhPermissions.Default;
            GetListPolicyName = Project_ABPPermissions.TinhPermissions.Default;
            CreatePolicyName = Project_ABPPermissions.TinhPermissions.Create;
            UpdatePolicyName = Project_ABPPermissions.TinhPermissions.Edit;
            DeletePolicyName = Project_ABPPermissions.TinhPermissions.Delete;

            _mapper = mapper;
            _tinhRepository = tinhRepository;
            _logger = logger;
        }

        public async Task<List<TinhDto>> GetAllTinhs()
        {
            try
            {
                var responses = await _tinhRepository.GetAllTinhs();
                return _mapper.Map<List<Tinh>, List<TinhDto>>(responses);
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
                var filter = _mapper.Map<TinhPagedAndSortedResultRequestDto, TinhFilter>(request);
                var sorting = string.IsNullOrEmpty(request.Sorting) ? "maTinh ASC" : request.Sorting;
                var response = await _tinhRepository.GetListAsync(request.SkipCount, request.MaxResultCount, sorting, filter);
                var totalCount = await _tinhRepository.GetTotalCountAsync(filter);
                return new PagedResultDto<TinhDto>(totalCount, _mapper.Map<List<Tinh>, List<TinhDto>>(response));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public override async Task<TinhDto> CreateAsync(CreateOrUpdateTinhDto input)
        {
            try
            {
                if (input.MaTinh <= 0) throw new Exception(message: "Mã tỉnh không được nhỏ hơn 1!");
                var listTinh = await _tinhRepository.GetAllTinhs();
                var listMaTinh = listTinh.Select(x => x.MaTinh).ToList();
                if (listMaTinh.Contains(input.MaTinh)) throw new Exception(message: "Mã tỉnh đã tồn tại!");
                var tinh = await base.CreateAsync(input);
                return tinh;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public override async Task<TinhDto> UpdateAsync(Guid id, CreateOrUpdateTinhDto input)
        {
            try
            {
                if (input.MaTinh <= 0) throw new Exception(message: "Mã tỉnh không được nhỏ hơn 1!");
                var tinhUpdate = await GetAsync(id);
                var maOfTinhUpdate = tinhUpdate.MaTinh;
                if (input.MaTinh != maOfTinhUpdate)
                {
                    var listTinh = await _tinhRepository.GetAllTinhs();
                    var listMaTinh = listTinh.Select(x => x.MaTinh).ToList();
                    if (listMaTinh.Contains(input.MaTinh)) throw new Exception(message: "Mã tỉnh đã tồn tại!");
                }
                var updatedTinhDto = await base.UpdateAsync(id, input);
                return updatedTinhDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task ImportExcel(List<TinhDto> listTinh)
        {
            try
            {
                var file = new FileInfo(@"C:\Users\Admin\Documents\Projects\ABP_Framework\excel\danh-sach-tinh.xlsx");
                var listDataExcel = _mapper.Map<List<ExcelDto>>(listTinh);
                var sheetName = "danh-sach-tinh";
                var title = "Danh sách tỉnh";
                await ExcelService.CreateExcelFile(file, listDataExcel, sheetName, title);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

        }
    }
}
