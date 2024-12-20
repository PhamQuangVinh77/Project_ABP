using Project_ABP.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Project_ABP.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(Project_ABPEntityFrameworkCoreModule),
    typeof(Project_ABPApplicationContractsModule)
    )]
public class Project_ABPDbMigratorModule : AbpModule
{
}
