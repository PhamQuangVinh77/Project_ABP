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
    public class TinhRepository : DapperRepository<Project_ABPDbContext>, ITinhRepository, ITransientDependency
    {
        public TinhRepository(IDbContextProvider<Project_ABPDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Tinh>> GetAllTinhs()
        {
            var dbConnection = await GetDbConnectionAsync();
            return (await dbConnection.QueryAsync<Tinh>("SELECT * FROM apptinh WHERE IsDeleted = 0",
                    transaction: DbTransaction)).ToList();
        }
    }
}
