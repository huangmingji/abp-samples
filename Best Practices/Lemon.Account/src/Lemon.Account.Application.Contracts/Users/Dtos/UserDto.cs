using System;
using System.Collections.Generic;

namespace Lemon.Account.Application
{

    /// <summary>
    /// 用户数据
    /// </summary>
    public class UserDto
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        /// <value>The account.</value>
        public string Account { get; set; } = "";

        /// <summary>
        /// 昵称
        /// </summary>
        /// <value>The name of the nike.</value>
        public string NickName { get; set; } = "";

        /// <summary>
        /// 头像
        /// </summary>
        /// <value>The head icon.</value>
        public string HeadIcon { get; set; } = "";

        /// <summary>
        /// 手机号码
        /// </summary>
        /// <value>The mobile.</value>
        public string Mobile { get; set; } = "";

        /// <summary>
        /// 电子邮箱
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; } = "";
        
        public bool IsDeleted { get; set; }

        public UserLogOnDto UserLogOn { get; set; }

        public List<UserRoleDto> UserRoles { get; set; }

    }
}