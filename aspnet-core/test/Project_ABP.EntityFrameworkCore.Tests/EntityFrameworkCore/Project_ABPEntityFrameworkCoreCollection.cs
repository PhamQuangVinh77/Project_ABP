using Xunit;

namespace Project_ABP.EntityFrameworkCore;

[CollectionDefinition(Project_ABPTestConsts.CollectionDefinitionName)]
public class Project_ABPEntityFrameworkCoreCollection : ICollectionFixture<Project_ABPEntityFrameworkCoreFixture>
{

}
