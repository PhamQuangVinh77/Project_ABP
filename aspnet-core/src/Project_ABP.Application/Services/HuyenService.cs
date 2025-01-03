using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Project_ABP.Dto.ExcelDtos;
using Project_ABP.Dto.HuyenDtos;
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

        public async Task ExportExcel(List<HuyenDto> listHuyen)
        {
            try
            {
                var path = $"{Directory.GetCurrentDirectory()}\\wwwroot\\export-excels";
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                var file = new FileInfo($"{path}\\danh-sach-huyen.xlsx");
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

        public override async Task<HuyenDto> CreateAsync(CreateOrUpdateHuyenDto input)
        {
            try
            {
                if (input.MaHuyen <= 0) throw new Exception(message: "Mã huyện không được nhỏ hơn 1!");
                var listHuyen = await _huyenRepository.GetAllHuyens(input.MaTinh);
                var listMaHuyen = listHuyen.Select(x => x.MaHuyen).ToList();
                if (listMaHuyen.Contains(input.MaHuyen)) throw new Exception(message: "Mã huyện đã tồn tại!");
                var huyen = await base.CreateAsync(input);
                return huyen;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public override async Task<HuyenDto> UpdateAsync(Guid id, CreateOrUpdateHuyenDto input)
        {
            try
            {
                if (input.MaHuyen <= 0) throw new Exception(message: "Mã huyện không được nhỏ hơn 1!");
                var huyenUpdate = await GetAsync(id);
                var maOfHuyenUpdate = huyenUpdate.MaHuyen;
                if (input.MaHuyen != maOfHuyenUpdate)
                {
                    var listHuyen = await _huyenRepository.GetAllHuyens(input.MaTinh);
                    var listMaHuyen = listHuyen.Select(x => x.MaHuyen).ToList();
                    if (listMaHuyen.Contains(input.MaHuyen)) throw new Exception(message: "Mã huyện đã tồn tại!");
                }
                var updatedHuyenDto = await base.UpdateAsync(id, input);
                return updatedHuyenDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
