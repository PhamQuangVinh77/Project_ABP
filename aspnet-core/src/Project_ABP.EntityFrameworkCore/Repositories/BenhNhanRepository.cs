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
    public class BenhNhanRepository : DapperRepository<Project_ABPDbContext>, IBenhNhanRepository, ITransientDependency
    {
        public BenhNhanRepository(IDbContextProvider<Project_ABPDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<BenhNhan>> GetAllBenhNhans(int hospitalId)
        {
            var dbConnection = await GetDbConnectionAsync();
            return (await dbConnection.QueryAsync<BenhNhan>("SELECT * FROM benhnhans WHERE IsDeleted = 0 AND HospitalId = @hospitalId", new { hospitalId },
                    transaction: DbTransaction)).ToList();
        }
    }
}
