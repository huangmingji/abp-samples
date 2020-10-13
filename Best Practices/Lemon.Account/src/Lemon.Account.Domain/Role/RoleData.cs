using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lemon.Account.Domain.Role
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class RoleData : AuditedAggregateRoot<Guid>
    {
        public RoleData()
        {
        }

        public RoleData(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        public ICollection<RolePermissionData> Permissions { get; set; } = new List<RolePermissionData>();
    }
}