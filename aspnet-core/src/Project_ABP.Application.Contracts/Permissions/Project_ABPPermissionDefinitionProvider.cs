using Project_ABP.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Project_ABP.Permissions;

public class Project_ABPPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var qlGroup = context.AddGroup(Project_ABPPermissions.GroupName, L("Permission:Management"));

        var tinhPermission = qlGroup.AddPermission(Project_ABPPermissions.TinhPermissions.Default, L("Permission:Tinhs"));
        tinhPermission.AddChild(Project_ABPPermissions.TinhPermissions.Create, L("Permission:Tinhs.Create"));
        tinhPermission.AddChild(Project_ABPPermissions.TinhPermissions.Edit, L("Permission:Tinhs.Edit"));
        tinhPermission.AddChild(Project_ABPPermissions.TinhPermissions.Delete, L("Permission:Tinhs.Delete"));

        var huyenPermission = qlGroup.AddPermission(Project_ABPPermissions.HuyenPermissions.Default, L("Permission:Huyens"));
        huyenPermission.AddChild(Project_ABPPermissions.HuyenPermissions.Create, L("Permission:Huyens.Create"));
        huyenPermission.AddChild(Project_ABPPermissions.HuyenPermissions.Edit, L("Permission:Huyens.Edit"));
        huyenPermission.AddChild(Project_ABPPermissions.HuyenPermissions.Delete, L("Permission:Huyens.Delete"));

        var xaPermission = qlGroup.AddPermission(Project_ABPPermissions.XaPermissions.Default, L("Permission:Xas"));
        xaPermission.AddChild(Project_ABPPermissions.XaPermissions.Create, L("Permission:Xas.Create"));
        xaPermission.AddChild(Project_ABPPermissions.XaPermissions.Edit, L("Permission:Xas.Edit"));
        xaPermission.AddChild(Project_ABPPermissions.XaPermissions.Delete, L("Permission:Xas.Delete"));

        var hospitalGroup = context.AddGroup(Project_ABPPermissions.HospitalDefault, L("Permission:Hospital"));
        var addHospitalPermission = hospitalGroup.AddPermission(Project_ABPPermissions.HospitalPermissions.Create, L("Permission:Create"));
        var editHospitalPermission = hospitalGroup.AddPermission(Project_ABPPermissions.HospitalPermissions.Edit, L("Permission:Edit"));
        var deleteHospitalPermission = hospitalGroup.AddPermission(Project_ABPPermissions.HospitalPermissions.Delete, L("Permission:Delete"));

        var bnGroup = context.AddGroup(Project_ABPPermissions.BenhNhanDefault, L("Permission:BenhNhan"));
        var addBNPermission = bnGroup.AddPermission(Project_ABPPermissions.BenhNhanPermissions.Create, L("Permission:Create"));
        var editBNPermission = bnGroup.AddPermission(Project_ABPPermissions.BenhNhanPermissions.Edit, L("Permission:Edit"));
        var deleteBNPermission = bnGroup.AddPermission(Project_ABPPermissions.BenhNhanPermissions.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<Project_ABPResource>(name);
    }
}
