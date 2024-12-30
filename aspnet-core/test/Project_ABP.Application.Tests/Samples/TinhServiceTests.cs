using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Project_ABP.Dto.TinhDto;
using Project_ABP.Entities;
using Project_ABP.IRepositories;
using Project_ABP.Services;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Project_ABP.Samples
{
    public class TinhServiceTests
    {
        private readonly Mock<IRepository<Tinh, Guid>> _repository;
        private readonly Mock<ITinhRepository> _tinhRepository;
        private Mock<ILogger<TinhService>> _logger;

        public TinhServiceTests()
        {
            _repository = new Mock<IRepository<Tinh, Guid>>();
            _tinhRepository = new Mock<ITinhRepository>();
            _logger = new Mock<ILogger<TinhService>>();
        }

        [Fact]
        public async Task CreateAsync_ValidInput_SuccessResult()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new Project_ABPApplicationAutoMapperProfile()));
            var _mapper = mockMapper.CreateMapper();

            var listTinh = new List<Tinh>
            {
                new Tinh { MaTinh = 30, TenTinh = "Hà Nội", Cap = "Thành phố trung ương"},
                new Tinh { MaTinh = 34, TenTinh = "Hải Dương", Cap = "Tỉnh"},
            };

            _tinhRepository.Setup(x => x.GetAllTinhs()).ReturnsAsync(listTinh);

            var tinhService = new TinhService(_mapper, _repository.Object, _tinhRepository.Object, _logger.Object);
            var result = await tinhService.CreateAsync(new CreateOrUpdateTinhDto()
            {
                MaTinh = 1,
                TenTinh = "Tỉnh Test",
                Cap = "Tỉnh"
            });
            Assert.NotNull(result);
        }
    }
}
