using System.Threading.Tasks;
using Dapper;
using Project_ABP.Entities;
using Project_ABP.EntityFrameworkCore;
using Project_ABP.IRepositories;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Users;

namespace Project_ABP.Repositories
{
    public class UserHospitalRepository : DapperRepository<Project_ABPDbContext>, IUserHospitalRepository, ITransientDependency
    {
        private readonly ICurrentUser _currentUser;
        public UserHospitalRepository(IDbContextProvider<Project_ABPDbContext> dbContextProvider, ICurrentUser currentUser) : base(dbContextProvider)
        {
            _currentUser = currentUser;
        }

        public async Task<int> GetHospitalIdByCurrentUser()
        {
            var userId = _currentUser.Id;
            var dbConnection = await GetDbConnectionAsync();
            return (await dbConnection.QueryFirstOrDefaultAsync<UserHospital>("SELECT * FROM userhospitals WHERE UserId = @userId", new { userId },
                    transaction: DbTransaction)).HospitalId;
        }
    }
}
