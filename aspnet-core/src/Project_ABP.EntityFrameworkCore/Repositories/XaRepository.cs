using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class XaRepository : DapperRepository<Project_ABPDbContext>, IXaRepository, ITransientDependency
    {
        public XaRepository(IDbContextProvider<Project_ABPDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Xa>> GetAllXas(int maTinh, int maHuyen)
        {
            var dbConnection = await GetDbConnectionAsync();
            return (await dbConnection.QueryAsync<Xa>("SELECT * FROM appxa WHERE IsDeleted = 0 AND MaTinh = @maTinh AND MaHuyen = @maHuyen", new {maTinh, maHuyen},
                    transaction: DbTransaction)).ToList();
        }
    }
}
