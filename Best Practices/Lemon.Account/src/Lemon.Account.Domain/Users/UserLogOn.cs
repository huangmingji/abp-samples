using System;
using Volo.Abp.Domain.Entities;

namespace Lemon.Account.Domain.Users
{
    /// <summary>
    /// 用户登录信息表
    /// </summary>
    public class UserLogOn : Entity
    {
        public UserLogOn()
        {
        }

        public UserLogOn(Guid userId, string password, string secretKey)
        {
            UserId = userId;
            Password = password;
            SecretKey = secretKey;
        }

        /// <summary>
        /// 用户主键
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = "";

        /// <summary>
        /// 用户密钥
        /// </summary>
        public string SecretKey { get; set; } = "";

        /// <summary>
        /// 允许登录时间开始
        /// </summary>
        public DateTime AllowStartTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 允许登录时间结束
        /// </summary>
        public DateTime AllowEndTime { get; set; } = DateTime.Now.AddYears(100);

        /// <summary>
        /// 暂停用户开始日期
        /// </summary>
        public DateTime LockStartTime { get; set; } = DateTime.Now.AddYears(100);

        /// <summary>
        /// 暂停用户结束日期
        /// </summary>
        public DateTime LockEndDate { get; set; } = DateTime.Now.AddYears(100);

        /// <summary>
        /// 第一次访问时间
        /// </summary>
        public DateTime FirstVisitTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 上一次访问时间
        /// </summary>
        public DateTime PreviousVisitTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 最后访问时间
        /// </summary>
        public DateTime LastVisitTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 最后修改密码日期
        /// </summary>
        public DateTime ChangPasswordDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 允许同时有多用户登录
        /// </summary>
        public bool MultiUserLogin { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        public int LogonCount { get; set; }

        /// <summary>
        /// 在线状态
        /// </summary>
        public bool UserOnline { get; set; } = false;

        public override object[] GetKeys()
        {
            return new object[] { UserId };
        }
    }
}