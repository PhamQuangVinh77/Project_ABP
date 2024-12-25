using System.Collections.Generic;
using System.Threading.Tasks;
using Project_ABP.Entities;
using Project_ABP.Filter;
using Volo.Abp.DependencyInjection;

namespace Project_ABP.IRepositories
{
    public interface IHuyenRepository : ITransientDependency
    {
        Task<List<Huyen>> GetAllHuyens(int? maTinh);
        Task<List<Huyen>> GetListAsync(int skipCount, int maxResultCount, string sorting = "", HuyenFilter filter = null);
        Task<int> GetTotalCountAsync(HuyenFilter filter);
    }
}
