using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project_ABP.Dto;
using Project_ABP.Entities;
using Project_ABP.IRepositories;
using Project_ABP.IServices;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Project_ABP.Services
{
    public class TinhService : CrudAppService<Tinh, TinhDto, Guid, PagedAndSortedResultRequestDto, CreateOrUpdateTinhDto, CreateOrUpdateTinhDto>, ITinhService
    {
        private readonly ITinhRepository _tinhRepository;
        public TinhService(IRepository<Tinh, Guid> repository, ITinhRepository tinhRepository) : base(repository)
        {
            _tinhRepository = tinhRepository;
        }        
        
        public async Task<List<TinhDto>> GetAllTinhs()
        {
            var responses = await _tinhRepository.GetAllTinhs();
            return ObjectMapper.Map<List<Tinh>, List<TinhDto>>(responses);
        }
    }
}
