using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Dapper;
using Project_ABP.Entities;
using Project_ABP.EntityFrameworkCore;
using Project_ABP.Filter;
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

        public async Task<Tinh> GetTinhById(Guid id)
        {
            var dbConnection = await GetDbConnectionAsync();
            return (await dbConnection.QueryFirstOrDefaultAsync<Tinh>("SELECT * FROM apptinh WHERE IsDeleted = 0 AND @Id = @id", new {id},
                    transaction: DbTransaction));
        }

        public async Task<List<Tinh>> GetListAsync(int skipCount, int maxResultCount, string sorting, TinhFilter filter)
        {
            var listTinh = await GetAllTinhs().ConfigureAwait(false);
            var response = listTinh.AsQueryable()
                                   .WhereIf(!filter.Filter.IsNullOrWhiteSpace(), x => x.TenTinh.ToLower().Contains(filter.Filter.ToLower()))
                                   .OrderBy(sorting)
                                   .Skip(skipCount)
                                   .Take(maxResultCount)
                                   .ToList();
            return response;                            
        }

        public async Task<int> GetTotalCountAsync(TinhFilter filter)
        {
            var listTinh = await GetAllTinhs().ConfigureAwait(false);
            var count = listTinh.WhereIf(!filter.Filter.IsNullOrWhiteSpace(), x => x.TenTinh.ToLower().Contains(filter.Filter.ToLower()))
                                .ToList().Count();
            return count;
        }
    }
}
