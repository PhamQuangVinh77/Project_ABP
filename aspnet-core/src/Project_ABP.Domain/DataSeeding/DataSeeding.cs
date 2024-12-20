using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Project_ABP.DataSeeding
{
    public class DataSeeding : IDataSeedContributor, ITransientDependency
    {
        public Task SeedAsync(DataSeedContext context)
        {
            throw new NotImplementedException();
        }
    }
}
