using Volo.Abp.Modularity;

namespace Project_ABP;

[DependsOn(
    typeof(Project_ABPDomainModule),
    typeof(Project_ABPTestBaseModule)
)]
public class Project_ABPDomainTestModule : AbpModule
{

}
