using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Project_ABP.IRepositories
{
    public interface IUserHospitalRepository : ITransientDependency
    {
        Task<int> GetHospitalIdByCurrentUser();
        Task<string> GetHospitalNameByCurrentUser();
    }
}
