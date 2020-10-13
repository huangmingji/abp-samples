using System;
using System.Collections.Generic;

namespace Lemon.Account.Application
{
    public class RoleDto
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        public List<RolePermissionDto> Permissions { get; set; }

    }
}