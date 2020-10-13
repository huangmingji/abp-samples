using System;
using Volo.Abp.Domain.Entities;

namespace Lemon.Account.Domain.Role
{
    public class RolePermissionData : Entity
    {
        public RolePermissionData()
        {
        }

        public RolePermissionData(Guid roleId, string permission)
        {
            RoleId = roleId;
            Permission = permission;
        }

        public Guid RoleId { get; set; }

        public string Permission { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { RoleId, Permission };
        }
    }
}