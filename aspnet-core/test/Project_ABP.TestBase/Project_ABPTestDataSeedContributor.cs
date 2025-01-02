using System;
using System.Threading.Tasks;
using Project_ABP.Entities;
using Project_ABP.IRepositories;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Project_ABP;

public class Project_ABPTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Tinh, Guid> _tinhRepository;
    public Project_ABPTestDataSeedContributor(IRepository<Tinh, Guid> tinhRepository)
    {
        _tinhRepository = tinhRepository;
    }
    public async Task SeedAsync(DataSeedContext context)
    {
        await _tinhRepository.InsertAsync(new Tinh
        {
            MaTinh = 30,
            TenTinh = "Hà Nội",
            Cap = "Thành phố trung ương"
        });

        await _tinhRepository.InsertAsync(new Tinh
        {
            MaTinh = 34,
            TenTinh = "Hải Dương",
            Cap = "Tỉnh"
        });

        await _tinhRepository.InsertAsync(new Tinh
        {
            MaTinh = 89,
            TenTinh = "Hưng Yên",
            Cap = "Tỉnh"
        });
    }
}
