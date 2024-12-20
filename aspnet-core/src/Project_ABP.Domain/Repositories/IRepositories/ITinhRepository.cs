using System.Collections.Generic;
using System.Threading.Tasks;
using Project_ABP.Entities;

namespace Project_ABP.Repositories.IRepositories
{
    public interface ITinhRepository
    {
        Task<List<Tinh>> GetAllTinhs();
    }
}
