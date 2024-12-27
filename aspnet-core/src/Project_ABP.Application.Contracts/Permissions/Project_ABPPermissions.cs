namespace Project_ABP.Permissions;

public static class Project_ABPPermissions
{
    public const string GroupName = "Management";
    public const string HospitalDefault = "Hospital";
    public const string BenhNhanDefault = "BenhNhan";
    public static class TinhPermissions
    {
        public const string Default = GroupName + ".Tinhs";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class HuyenPermissions
    {
        public const string Default = GroupName + ".Huyens";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class XaPermissions
    {
        public const string Default = GroupName + ".Xas";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class HospitalPermissions
    {
        public const string Create = HospitalDefault + ".Create";
        public const string Edit = HospitalDefault + ".Edit";
        public const string Delete = HospitalDefault + ".Delete";
    }

    public static class BenhNhanPermissions
    {
        public const string Create = BenhNhanDefault + ".Create";
        public const string Edit = BenhNhanDefault + ".Edit";
        public const string Delete = BenhNhanDefault + ".Delete";
    }
}
