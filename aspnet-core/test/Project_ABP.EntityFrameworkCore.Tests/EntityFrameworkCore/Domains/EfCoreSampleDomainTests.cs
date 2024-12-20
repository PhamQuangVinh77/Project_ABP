using Project_ABP.Samples;
using Xunit;

namespace Project_ABP.EntityFrameworkCore.Domains;

[Collection(Project_ABPTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<Project_ABPEntityFrameworkCoreTestModule>
{

}
