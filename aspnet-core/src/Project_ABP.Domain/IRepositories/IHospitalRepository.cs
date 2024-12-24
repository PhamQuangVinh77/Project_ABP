using System.Collections.Generic;
using System.Threading.Tasks;
using Project_ABP.Entities;
using Volo.Abp.DependencyInjection;

namespace Project_ABP.IRepositories
{
    public interface IHospitalRepository : ITransientDependency
    {
        Task<List<Hospital>> GetAllHospitals(int maTinh, int maHuyen, int maXa);
    }
}
