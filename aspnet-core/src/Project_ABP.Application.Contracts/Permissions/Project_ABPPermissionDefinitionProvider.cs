using Project_ABP.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Project_ABP.Permissions;

public class Project_ABPPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(Project_ABPPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(Project_ABPPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<Project_ABPResource>(name);
    }
}
