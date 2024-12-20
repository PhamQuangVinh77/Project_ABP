using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Project_ABP.Data;

/* This is used if database provider does't define
 * IProject_ABPDbSchemaMigrator implementation.
 */
public class NullProject_ABPDbSchemaMigrator : IProject_ABPDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
