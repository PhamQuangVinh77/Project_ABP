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
    public class HuyenRepository : DapperRepository<Project_ABPDbContext>, IHuyenRepository, ITransientDependency
    {
        public HuyenRepository(IDbContextProvider<Project_ABPDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Huyen>> GetAllHuyens(int? maTinh)
        {
            var dbConnection = await GetDbConnectionAsync();
            return (await dbConnection.QueryAsync<Huyen>("SELECT * FROM apphuyen WHERE IsDeleted = 0 AND MaTinh = @maTinh", new { maTinh },
                    transaction: DbTransaction)).ToList();
        }

        public async Task<List<Huyen>> GetListAsync(int skipCount, int maxResultCount, string sorting = "", HuyenFilter filter = null)
        {
            var listHuyen = await GetAllHuyens(filter.MaTinh).ConfigureAwait(false);
            var response = listHuyen.AsQueryable()
                                   .WhereIf(!filter.Filter.IsNullOrWhiteSpace(), x => x.TenHuyen.ToLower().Contains(filter.Filter.ToLower()))
                                   .OrderBy(sorting)
                                   .Skip(skipCount)
                                   .Take(maxResultCount)
                                   .ToList();
            return response;
        }

        public async Task<int> GetTotalCountAsync(HuyenFilter filter)
        {
            var listHuyen = await GetAllHuyens(filter.MaTinh).ConfigureAwait(false);
            var count = listHuyen.WhereIf(!filter.Filter.IsNullOrWhiteSpace(), x => x.TenHuyen.ToLower().Contains(filter.Filter.ToLower()))
                                .ToList().Count();
            return count;
        }
    }
}
