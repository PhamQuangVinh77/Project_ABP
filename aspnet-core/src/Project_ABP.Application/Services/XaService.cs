using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Project_ABP.Dto.ExcelDtos;
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
        private readonly IMapper _mapper;
        private readonly IXaRepository _xaRepository;
        private ILogger<XaService> _logger;
        public XaService(IMapper mapper, IRepository<Xa, Guid> repository, IXaRepository xaRepository, ILogger<XaService> logger) : base(repository)
        {
            GetPolicyName = Project_ABPPermissions.XaPermissions.Default;
            GetListPolicyName = Project_ABPPermissions.XaPermissions.Default;
            CreatePolicyName = Project_ABPPermissions.XaPermissions.Create;
            UpdatePolicyName = Project_ABPPermissions.XaPermissions.Edit;
            DeletePolicyName = Project_ABPPermissions.XaPermissions.Delete;

            _mapper = mapper;
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

        public async Task ExportExcel(List<XaDto> listXa)
        {
            try
            {
                var path = $"{Directory.GetCurrentDirectory()}\\wwwroot\\export-excels";
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                var file = new FileInfo($"{path}\\danh-sach-xa.xlsx");
                var listDataExcel = _mapper.Map<List<ExcelDto>>(listXa);
                var sheetName = "danh-sach-xa";
                var title = "Danh sách xã";
                await ExcelService.CreateExcelFile(file, listDataExcel, sheetName, title);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

        }

        public override async Task<XaDto> CreateAsync(CreateOrUpdateXaDto input)
        {
            try
            {
                if (input.MaXa <= 0) throw new Exception(message: "Mã xã không được nhỏ hơn 1!");
                var listXa = await _xaRepository.GetAllXas(input.MaTinh, input.MaHuyen);
                var listMaXa = listXa.Select(x => x.MaXa).ToList();
                if (listMaXa.Contains(input.MaXa)) throw new Exception(message: "Mã xã đã tồn tại!");
                var xa = await base.CreateAsync(input);
                return xa;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public override async Task<XaDto> UpdateAsync(Guid id, CreateOrUpdateXaDto input)
        {
            try
            {
                if (input.MaXa <= 0) throw new Exception(message: "Mã xã không được nhỏ hơn 1!");
                var xaUpdate = await GetAsync(id);
                var maOfXaUpdate = xaUpdate.MaXa;
                if (input.MaXa != maOfXaUpdate)
                {
                    var listXa = await _xaRepository.GetAllXas(input.MaTinh, input.MaHuyen);
                    var listMaXa = listXa.Select(x => x.MaXa).ToList();
                    if (listMaXa.Contains(input.MaXa)) throw new Exception(message: "Mã xã đã tồn tại!");
                }
                var updatedXaDto = await base.UpdateAsync(id, input);
                return updatedXaDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
