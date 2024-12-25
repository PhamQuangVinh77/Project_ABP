using System.Collections.Generic;
using System.Threading.Tasks;
using Project_ABP.Entities;
using Project_ABP.Filter;
using Volo.Abp.DependencyInjection;

namespace Project_ABP.IRepositories
{
    public interface IXaRepository : ITransientDependency
    {
        Task<List<Xa>> GetAllXas(int? maTinh, int? maHuyenen);
        Task<List<Xa>> GetListAsync(int skipCount, int maxResultCount, string sorting = "", XaFilter filter = null);
        Task<int> GetTotalCountAsync(XaFilter filter);
    }
}
