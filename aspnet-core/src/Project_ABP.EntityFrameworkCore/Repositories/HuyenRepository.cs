using System;
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
    public class HuyenRepository : DapperRepository<Project_ABPDbContext>, IHuyenRepository, ITransientDependency
    {
        public HuyenRepository(IDbContextProvider<Project_ABPDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Huyen>> GetAllHuyens(int maTinh)
        {
            var dbConnection = await GetDbConnectionAsync();
            return (await dbConnection.QueryAsync<Huyen>("SELECT * FROM apphuyen WHERE IsDeleted = 0 AND MaTinh = @maTinh", new {maTinh},
                    transaction: DbTransaction)).ToList();
        }
    }
}
