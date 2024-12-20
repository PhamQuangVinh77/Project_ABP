using Volo.Abp.Modularity;

namespace Project_ABP;

public abstract class Project_ABPApplicationTestBase<TStartupModule> : Project_ABPTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
