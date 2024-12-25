using System.Collections.Generic;
using System.Threading.Tasks;
using Project_ABP.Entities;
using Project_ABP.Filter;
using Volo.Abp.DependencyInjection;

namespace Project_ABP.IRepositories
{
    public interface IHospitalRepository : ITransientDependency
    {
        Task<List<Hospital>> GetAllHospitals(int? maTinh, int? maHuyen, int? maXa);
        Task<List<Hospital>> GetListAsync(int skipCount, int maxResultCount, string sorting = "", HospitalFilter filter = null);
        Task<int> GetTotalCountAsync(HospitalFilter filter);
    }
}
