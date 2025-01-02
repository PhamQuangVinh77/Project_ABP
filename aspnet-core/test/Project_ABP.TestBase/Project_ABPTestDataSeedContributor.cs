using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Project_ABP;

public class Project_ABPTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    public async Task SeedAsync(DataSeedContext context)
    {
        await Task.CompletedTask;
    }
}
