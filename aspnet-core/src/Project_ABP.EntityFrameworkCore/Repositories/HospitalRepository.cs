using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Project_ABP.Entities;
using Project_ABP.EntityFrameworkCore;
using Project_ABP.IRepositories;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;

namespace Project_ABP.Repositories
{
    public class HospitalRepository : DapperRepository<Project_ABPDbContext>, IHospitalRepository, ITransientDependency
    {
        public HospitalRepository(IDbContextProvider<Project_ABPDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Hospital>> GetAllHospitals(int maTinh, int maHuyen, int maXa)
        {
            var dbConnection = await GetDbConnectionAsync();
            return (await dbConnection.QueryAsync<Hospital>("SELECT * FROM hospitals WHERE IsDeleted = 0 AND MaTinh = @maTinh AND MaHuyen = @maHuyen AND MaXa = @maXa",
                    new { maTinh, maHuyen, maXa }, transaction: DbTransaction)).ToList();
        }
    }
}
