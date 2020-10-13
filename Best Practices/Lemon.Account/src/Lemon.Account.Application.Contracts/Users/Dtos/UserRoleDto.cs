using System;

namespace Lemon.Account.Application
{
    /// <summary>
    /// 用户角色
    /// </summary>
    public class UserRoleDto
    {

        /// <summary>
        /// 用户主键
        /// </summary>
        public Guid UserId { get; set; }
        
        /// <summary>
        /// 角色主键
        /// </summary>
        public Guid RoleId { get; set; }

        public RoleDto RoleData { get; set; }
    }
}