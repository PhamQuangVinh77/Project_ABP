using System.Collections.Generic;
using System.Threading.Tasks;
using Project_ABP.Entities;
using Project_ABP.Filter;
using Volo.Abp.DependencyInjection;

namespace Project_ABP.IRepositories
{
    public interface IBenhNhanRepository : ITransientDependency
    {
        Task<List<BenhNhan>> GetAllBenhNhans(int? hospitalId);
        Task<List<BenhNhan>> GetListAsync(int skipCount, int maxResultCount, string sorting = "", BenhNhanFilter filter = null);
        Task<int> GetTotalCountAsync(BenhNhanFilter filter);
    }
}
