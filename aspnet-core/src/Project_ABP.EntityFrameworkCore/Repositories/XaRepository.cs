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
    public class XaRepository : DapperRepository<Project_ABPDbContext>, IXaRepository, ITransientDependency
    {
        public XaRepository(IDbContextProvider<Project_ABPDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Xa>> GetAllXas(int? maTinh, int? maHuyen)
        {
            var dbConnection = await GetDbConnectionAsync();
            return (await dbConnection.QueryAsync<Xa>("SELECT * FROM appxa WHERE IsDeleted = 0 AND MaTinh = @maTinh AND MaHuyen = @maHuyen", new { maTinh, maHuyen },
                    transaction: DbTransaction)).ToList();
        }

        public async Task<List<Xa>> GetListAsync(int skipCount, int maxResultCount, string sorting = "", XaFilter filter = null)
        {
            var listXa = await GetAllXas(filter.MaTinh, filter.MaHuyen).ConfigureAwait(false);
            var response = listXa.AsQueryable()
                                   .WhereIf(!filter.Filter.IsNullOrWhiteSpace(), x => x.TenXa.ToLower().Contains(filter.Filter.ToLower()))
                                   .OrderBy(sorting)
                                   .Skip(skipCount)
                                   .Take(maxResultCount)
                                   .ToList();
            return response;
        }

        public async Task<int> GetTotalCountAsync(XaFilter filter)
        {
            var listXa = await GetAllXas(filter.MaTinh, filter.MaHuyen).ConfigureAwait(false);
            var count = listXa.WhereIf(!filter.Filter.IsNullOrWhiteSpace(), x => x.TenXa.ToLower().Contains(filter.Filter.ToLower()))
                                .ToList().Count();
            return count;
        }
    }
}
