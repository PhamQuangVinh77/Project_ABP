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
    public class BenhNhanRepository : DapperRepository<Project_ABPDbContext>, IBenhNhanRepository, ITransientDependency
    {
        public BenhNhanRepository(IDbContextProvider<Project_ABPDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<BenhNhan>> GetAllBenhNhans(int? hospitalId)
        {
            if (String.IsNullOrEmpty(hospitalId.ToString())) return new List<BenhNhan>();
            var dbConnection = await GetDbConnectionAsync();
            return (await dbConnection.QueryAsync<BenhNhan>("SELECT * FROM benhnhans WHERE IsDeleted = 0 AND HospitalId = @hospitalId", new { hospitalId },
                    transaction: DbTransaction)).ToList();
        }

        public async Task<List<BenhNhan>> GetListAsync(int skipCount, int maxResultCount, string sorting = "", BenhNhanFilter filter = null)
        {
            var listBenhNhan = await GetAllBenhNhans(filter.HospitalId).ConfigureAwait(false);
            var response = listBenhNhan.AsQueryable()
                                   .WhereIf(!filter.Filter.IsNullOrWhiteSpace(), x => x.Ten.ToLower().Contains(filter.Filter.ToLower()))
                                   .OrderBy(sorting)
                                   .Skip(skipCount)
                                   .Take(maxResultCount)
                                   .ToList();
            return response;
        }

        public async Task<int> GetTotalCountAsync(BenhNhanFilter filter)
        {
            var listBenhNhan = await GetAllBenhNhans(filter.HospitalId).ConfigureAwait(false);
            var count = listBenhNhan.WhereIf(!filter.Filter.IsNullOrWhiteSpace(), x => x.Ten.ToLower().Contains(filter.Filter.ToLower()))
                                .ToList().Count();
            return count;
        }
    }
}
