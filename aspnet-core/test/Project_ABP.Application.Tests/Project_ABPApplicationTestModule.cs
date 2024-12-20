using Volo.Abp.Modularity;

namespace Project_ABP;

[DependsOn(
    typeof(Project_ABPApplicationModule),
    typeof(Project_ABPDomainTestModule)
)]
public class Project_ABPApplicationTestModule : AbpModule
{

}
