using System;

namespace Lemon.Account.Application
{
    public class PermissionDto
    {
        public Guid Id { get; set; }

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