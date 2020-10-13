using System;
using Lemon.Account.Domain.Role;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Users;

namespace Lemon.Account.Domain.Users
{
    /// <summary>
    /// 用户角色
    /// </summary>
    public class UserRole : AuditedAggregateRoot<Guid>
    {
        public UserRole()
        {
        }

        public UserRole(Guid id, Guid userId, Guid roleId)
        {
            Id = id;
            UserId = userId;
            RoleId = roleId;
        }

        /// <summary>
        /// 用户主键
        /// </summary>
        public Guid UserId { get; set; }
        
        /// <summary>
        /// 角色主键
        /// </summary>
        public Guid RoleId { get; set; }

        public RoleData RoleData { get; set; }

    }
}