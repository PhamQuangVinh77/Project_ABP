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
    public class HuyenService : CrudAppService<Huyen, HuyenDto, Guid, PagedAndSortedResultRequestDto, CreateOrUpdateHuyenDto, CreateOrUpdateHuyenDto>, IHuyenService
    {
        private readonly IHuyenRepository _huyenRepository;
        public HuyenService(IRepository<Huyen, Guid> repository, IHuyenRepository huyenRepository) : base(repository)
        {
            _huyenRepository = huyenRepository;
        }

        public async Task<List<HuyenDto>> GetAllHuyens(int maTinh)
        {
            var response = await _huyenRepository.GetAllHuyens(maTinh);
            return ObjectMapper.Map<List<Huyen>, List<HuyenDto>>(response);
        }
    }
}
