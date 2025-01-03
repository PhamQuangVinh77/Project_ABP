using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Project_ABP.Dto.TinhDto;
using Project_ABP.Entities;
using Project_ABP.Filter;
using Project_ABP.IRepositories;
using Project_ABP.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Project_ABP.Samples
{
    public class TinhServiceTests
    {
        private readonly Mock<IRepository<Tinh, Guid>> _repository;
        private readonly Mock<ITinhRepository> _tinhRepository;
        private readonly Mock<ILogger<TinhService>> _logger;
        private readonly IMapper _mapper;
        private readonly TinhService _tinhService;
        public TinhServiceTests()
        {
            _repository = new Mock<IRepository<Tinh, Guid>>();
            _tinhRepository = new Mock<ITinhRepository>();
            _logger = new Mock<ILogger<TinhService>>();
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new Project_ABPApplicationAutoMapperProfile()));
            _mapper = mockMapper.CreateMapper();

            _tinhService = new TinhService(_mapper, _repository.Object, _tinhRepository.Object, _logger.Object);
        }

        [Fact]
        public async Task GetAllTinhs_ValidQuery_SuccessResult()
        {
            var listTinh = new List<Tinh>
            {
                new Tinh { MaTinh = 30, TenTinh = "Hà Nội", Cap = "Thành phố trung ương"},
                new Tinh { MaTinh = 34, TenTinh = "Hải Dương", Cap = "Tỉnh"},
                new Tinh { MaTinh = 89, TenTinh = "Hưng Yên", Cap = "Tỉnh"},
                new Tinh { MaTinh = 17, TenTinh = "Thái Bình", Cap = "Tỉnh"},
            };
            _tinhRepository.Setup(x => x.GetAllTinhs()).ReturnsAsync(listTinh);
            var result = await _tinhService.GetAllTinhs();
            Assert.Equal(listTinh.Count, result.Count);
        }

        [Fact]
        public async Task GetListAsync_ValidQuery_SuccessResult()
        {
            TinhPagedAndSortedResultRequestDto request = new TinhPagedAndSortedResultRequestDto
            {
                SkipCount = 0,
                MaxResultCount = 3,
                Sorting = "maTinh ASC",
                Filter = ""
            };
            TinhFilter filter = _mapper.Map<TinhPagedAndSortedResultRequestDto, TinhFilter>(request);

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
            _tinhRepository.Setup(x => x.GetAllTinhs()).ReturnsAsync(listAllTinh);
            _tinhRepository.Setup(x => x.GetTotalCountAsync(It.IsAny<TinhFilter>())).ReturnsAsync(listAllTinh.Count);
            _tinhRepository.Setup(x => x.GetListAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<TinhFilter>()))
                .ReturnsAsync(listPaggingTinh);

            var result = await _tinhService.GetListAsync(request);
            Assert.Equal(listAllTinh.Count, result.TotalCount);
            Assert.Equal(listPaggingTinh.Count, result.Items.Count);
        }

        [Fact]
        public async Task CreateAsync_InputValidation_ShouldThrowException()
        {
            var inputMaTinhIsSmallerThan1 = new CreateOrUpdateTinhDto()
            {
                MaTinh = 0,
                TenTinh = "Tỉnh với Mã Zero",
                Cap = "Tỉnh"
            };
            var inputMaTinhIsExist = new CreateOrUpdateTinhDto()
            {
                MaTinh = 30,
                TenTinh = "Tỉnh đã tồn tại",
                Cap = "Tỉnh"
            };
            var listTinh = new List<Tinh>
            {
                new Tinh { MaTinh = 30, TenTinh = "Hà Nội", Cap = "Thành phố trung ương"},
                new Tinh { MaTinh = 34, TenTinh = "Hải Dương", Cap = "Tỉnh"},
            };
            _tinhRepository.Setup(x => x.GetAllTinhs()).ReturnsAsync(listTinh);

            var checkMaIsSmallerThan1 = await Assert.ThrowsAsync<Exception>(() => _tinhService.CreateAsync(inputMaTinhIsSmallerThan1));
            Assert.Equal("Mã tỉnh không được nhỏ hơn 1!", checkMaIsSmallerThan1.Message);

            var checkMaExist = await Assert.ThrowsAsync<Exception>(() => _tinhService.CreateAsync(inputMaTinhIsExist));
            Assert.Equal("Mã tỉnh đã tồn tại!", checkMaExist.Message);

        }

        [Fact]
        public async Task UpdateAsync_InputValidation_ShouldThrowException()
        {
            var id = Guid.NewGuid();
            var inputMaTinhIsSmallerThan1 = new CreateOrUpdateTinhDto()
            {
                MaTinh = 0,
                TenTinh = "Tỉnh với Mã Zero",
                Cap = "Tỉnh"
            };
            var inputMaTinhIsExist = new CreateOrUpdateTinhDto()
            {
                MaTinh = 30,
                TenTinh = "Tỉnh đã tồn tại",
                Cap = "Tỉnh"
            };
            var listTinh = new List<Tinh>
            {
                new Tinh { MaTinh = 30, TenTinh = "Hà Nội", Cap = "Thành phố trung ương"},
                new Tinh { MaTinh = 34, TenTinh = "Hải Dương", Cap = "Tỉnh"},
            };

            _tinhRepository.Setup(x => x.GetAllTinhs()).ReturnsAsync(listTinh);
            _tinhRepository.Setup(x => x.GetTinhById(It.IsAny<Guid>())).ReturnsAsync(listTinh[1]);

            var checkMaIsSmallerThan1 = await Assert.ThrowsAsync<Exception>(() => _tinhService.UpdateAsync(id, inputMaTinhIsSmallerThan1));
            Assert.Equal("Mã tỉnh không được nhỏ hơn 1!", checkMaIsSmallerThan1.Message);

            var checkMaExist = await Assert.ThrowsAsync<Exception>(() => _tinhService.UpdateAsync(id, inputMaTinhIsExist));
            Assert.Equal("Mã tỉnh đã tồn tại!", checkMaExist.Message);
        }
    }
}
