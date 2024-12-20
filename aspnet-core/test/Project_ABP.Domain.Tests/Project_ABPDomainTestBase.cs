using Volo.Abp.Modularity;

namespace Project_ABP;

/* Inherit from this class for your domain layer tests. */
public abstract class Project_ABPDomainTestBase<TStartupModule> : Project_ABPTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
