using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Lemon.Account.Domain.Role
{
    /// <summary>
    /// 权限
    /// </summary>
    public sealed class PermissionData : AuditedEntity<Guid>
    {
        public PermissionData()
        {
        }

        public PermissionData(Guid id, string name, string permission, Guid? parentId = null)
        {
            Id = id;
            ParentId = parentId;
            Name = name;
            Permission = permission;
        }

        /// <summary>
        /// 上机主键
        /// </summary>
        public Guid? ParentId { get; set; }
        
        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 权限
        /// </summary>
        public string Permission { get; set; }
    }
}