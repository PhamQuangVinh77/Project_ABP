using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project_ABP.Data;
using Volo.Abp.DependencyInjection;

namespace Project_ABP.EntityFrameworkCore;

public class EntityFrameworkCoreProject_ABPDbSchemaMigrator
    : IProject_ABPDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreProject_ABPDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the Project_ABPDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<Project_ABPDbContext>()
            .Database
            .MigrateAsync();
    }
}
