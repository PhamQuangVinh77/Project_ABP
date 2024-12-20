using Project_ABP.Samples;
using Xunit;

namespace Project_ABP.EntityFrameworkCore.Applications;

[Collection(Project_ABPTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<Project_ABPEntityFrameworkCoreTestModule>
{

}
