using System;
using Volo.Abp.Domain.Entities;

namespace Lemon.UserCenter.Domain
{
    public class UserData : Entity<Guid>
    {
        /// <summary>
        /// 账号
        /// </summary>
        /// <value>The account.</value>
        public string Account { get; set; }

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

        /// <summary>
        /// 删除注记
        /// </summary>
        /// <value><c>true</c> if deleted; otherwise, <c>false</c>.</value>
        public bool Deleted { get; set; }
    }
}