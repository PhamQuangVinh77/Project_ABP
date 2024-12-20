using System.Threading.Tasks;

namespace Project_ABP.Data;

public interface IProject_ABPDbSchemaMigrator
{
    Task MigrateAsync();
}
