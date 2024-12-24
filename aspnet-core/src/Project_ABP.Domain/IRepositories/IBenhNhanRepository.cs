using System.Collections.Generic;
using System.Threading.Tasks;
using Project_ABP.Entities;
using Volo.Abp.DependencyInjection;

namespace Project_ABP.IRepositories
{
    public interface IBenhNhanRepository : ITransientDependency
    {
        Task<List<BenhNhan>> GetAllBenhNhans(int hospitalId);
    }
}
