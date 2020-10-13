using Volo.Abp.Reflection;

namespace Lemon.Account.Application.Contracts.Permissions
{
    public class AccountPermissions
    {
        private const string GroupName = "Lemon.Account";

        public static class User
        {
            private const string Default = GroupName + ".User";
            public const string Search = Default + ".Search";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string UpdateMobile = Default + ".UpdateMobile";
        }

        public static class Role
        {
            private const string Default = GroupName + ".Role";
            public const string Search = Default + ".Search";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }

        public static class Permission
        {
            private const string Default = GroupName + ".Permission";
            public const string Search = Default + ".Search";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(AccountPermissions));
        }
    }
}