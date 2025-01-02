using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Project_ABP.Dto.TinhDto;
using Project_ABP.Entities;
using Project_ABP.Filter;
using Project_ABP.IRepositories;
using Project_ABP.IServices;
using Project_ABP.Services;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Project_ABP.Samples
{
    public class TinhServiceTests<TStartupModule> : Project_ABPApplicationTestBase<TStartupModule> where TStartupModule : IAbpModule
    {
        private readonly Mock<IRepository<Tinh, Guid>> _repository;
        private readonly Mock<ITinhRepository> _tinhRepository;
        private readonly Mock<ILogger<TinhService>> _logger;
        private readonly IMapper _mapper;
        private readonly TinhService _tinhService;
        private readonly ITinhService _tinhServiceTest;
        public TinhServiceTests()
        {
            _repository = new Mock<IRepository<Tinh, Guid>>();
            _tinhRepository = new Mock<ITinhRepository>();
            _logger = new Mock<ILogger<TinhService>>();
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new Project_ABPApplicationAutoMapperProfile()));
            _mapper = mockMapper.CreateMapper();

            _tinhService = new TinhService(_mapper, _repository.Object, _tinhRepository.Object, _logger.Object);
            _tinhServiceTest = GetRequiredService<ITinhService>();
        }

        [Fact]
        public async Task GetAllTinhs_ValidQuery_SuccessResult()
        {
            //var listTinh = new List<Tinh>
            //{
            //    new Tinh { MaTinh = 30, TenTinh = "Hà Nội", Cap = "Thành phố trung ương"},
            //    new Tinh { MaTinh = 34, TenTinh = "Hải Dương", Cap = "Tỉnh"},
            //    new Tinh { MaTinh = 89, TenTinh = "Hưng Yên", Cap = "Tỉnh"},
            //    new Tinh { MaTinh = 17, TenTinh = "Thái Bình", Cap = "Tỉnh"},
            //};
            //_tinhRepository.Setup(x => x.GetAllTinhs()).ReturnsAsync(listTinh);
            //var result = await _tinhService.GetAllTinhs();
            //Assert.Equal(listTinh.Count, result.Count);
            var result = await _tinhServiceTest.GetListAsync(new TinhPagedAndSortedResultRequestDto());
            result.TotalCount.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task GetListAsync_ValidQuery_SuccessResult()
        {
            TinhPagedAndSortedResultRequestDto request = new TinhPagedAndSortedResultRequestDto
            {
                SkipCount = 0,
                MaxResultCount = 3,
                Sorting = "maTinh ASC",
                Filter = string.Empty,
            };
            TinhFilter filter = new TinhFilter
            {
                Filter = string.Empty,
            };
            var listAllTinh = new List<Tinh>
            {
                new Tinh { MaTinh = 15, TenTinh = "Hải Phòng", Cap = "Tỉnh"},
                new Tinh { MaTinh = 17, TenTinh = "Thái Bình", Cap = "Tỉnh"},
                new Tinh { MaTinh = 30, TenTinh = "Hà Nội", Cap = "Thành phố trung ương"},
                new Tinh { MaTinh = 34, TenTinh = "Hải Dương", Cap = "Tỉnh"},
                new Tinh { MaTinh = 89, TenTinh = "Hưng Yên", Cap = "Tỉnh"},
            };
            var listPaggingTinh = new List<Tinh>
            {
                new Tinh { MaTinh = 15, TenTinh = "Hải Phòng", Cap = "Tỉnh"},
                new Tinh { MaTinh = 17, TenTinh = "Thái Bình", Cap = "Tỉnh"},
                new Tinh { MaTinh = 30, TenTinh = "Hà Nội", Cap = "Thành phố trung ương"},
            };
            _tinhRepository.Setup(x => x.GetTotalCountAsync(filter)).ReturnsAsync(listAllTinh.Count);
            _tinhRepository.Setup(x => x.GetListAsync(request.SkipCount, request.MaxResultCount, request.Sorting, filter))
                .ReturnsAsync(listPaggingTinh);
            var result = await _tinhService.GetListAsync(request);
            Assert.Equal(listAllTinh.Count, result.TotalCount);
            Assert.Equal(listPaggingTinh.Count, result.Items.Count);
        }

        [Fact]
        public async Task CreateAsync_ValidInput_SuccessResult()
        {
            var input = new CreateOrUpdateTinhDto()
            {
                MaTinh = 1,
                TenTinh = "Tỉnh Test",
                Cap = "Tỉnh"
            };
            var listTinh = new List<Tinh>
            {
                new Tinh { MaTinh = 30, TenTinh = "Hà Nội", Cap = "Thành phố trung ương"},
                new Tinh { MaTinh = 34, TenTinh = "Hải Dương", Cap = "Tỉnh"},
            };
            _tinhRepository.Setup(x => x.GetAllTinhs()).ReturnsAsync(listTinh);

            var result = await _tinhService.CreateAsync(input);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateAsync_ValidInput_SuccessResult()
        {
            var id = Guid.Parse("00000000-0000-0000-0000-000000000000");
            var listTinh = new List<Tinh>
            {
                new Tinh { MaTinh = 30, TenTinh = "Hà Nội", Cap = "Thành phố trung ương"},
                new Tinh { MaTinh = 34, TenTinh = "Hải Dương", Cap = "Tỉnh"},
            };

            _tinhRepository.Setup(x => x.GetAllTinhs()).ReturnsAsync(listTinh);

            var result = await _tinhService.UpdateAsync(id, new CreateOrUpdateTinhDto()
            {
                MaTinh = 1,
                TenTinh = "Tỉnh Test",
                Cap = "Tỉnh"
            });
            Assert.NotNull(result);
        }
    }
}
