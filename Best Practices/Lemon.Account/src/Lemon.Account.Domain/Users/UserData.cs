using System;
using System.Collections.Generic;
using Lemon.Common;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Lemon.Account.Domain.Users
{

    /// <summary>
    /// 用户数据
    /// </summary>
    public sealed class UserData : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        private ICollection<UserRole> _userRoles = new List<UserRole>();

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
        public string Mobile { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }
        
        public bool IsDeleted { get; set; }
        
        public UserLogOn UserLogOn { get; set; }

        public ICollection<UserRole> UserRoles
        {
            get => _userRoles;
            set => _userRoles = value;
        }

        public UserData()
        {
        }

        public UserData(Guid id, string password, string name, string email)
            : this(id, null, password, name, null, email)
        {

        }

        public UserData(Guid id, string  account, string password, string name = "", string mobile = null, string email = null)
        {
            Check.NotNull(password, nameof(password));

            Id = id;
            NickName = name;
            Account = string.IsNullOrWhiteSpace(account) ? Guid.NewGuid().ToString("N") : account;
            Mobile = mobile;
            Email = email;
            string passwordHash = Cryptography.PasswordStorage.CreateHash(password, out string secretKey);
            UserLogOn = new UserLogOn(id, passwordHash, secretKey);
        }

        public void RemoveRole(Guid roleId)
        {
            UserRoles.RemoveAll(x => x.RoleId == roleId);
        }

        public void AddRole(Guid id, Guid roleId)
        {
            UserRoles.Add(new UserRole(id, Id, roleId));
        }

        public void UpdatePassword(string password)
        {
            string passwordHash = Cryptography.PasswordStorage.CreateHash(password, out string secretKey);
            UserLogOn.Password = passwordHash;
            UserLogOn.SecretKey = secretKey;
            UserLogOn.ChangPasswordDate = DateTime.Now;
        }

        public void UpdateLoginInfo()
        {
            UserLogOn.FirstVisitTime = UserLogOn.LogonCount == 0 ? DateTime.Now : UserLogOn.FirstVisitTime;
            UserLogOn.LogonCount += 1;
            UserLogOn.UserOnline = true;
            UserLogOn.PreviousVisitTime = UserLogOn.LastVisitTime;
            UserLogOn.LastVisitTime = DateTime.Now;
        }

        public void Logout()
        {
            UserLogOn.UserOnline = false;
        }

        public bool VerifyPassword(string password)
        {
            return Cryptography.PasswordStorage.VerifyPassword(password, UserLogOn.Password, UserLogOn.SecretKey);
        }

        public void LockUser(DateTime startTime, DateTime endTime)
        {
            UserLogOn.LockStartTime = startTime;
            UserLogOn.LockEndDate = endTime;
        }

        public void AllowUser(DateTime startTime, DateTime endTime)
        {
            UserLogOn.AllowStartTime = startTime;
            UserLogOn.AllowEndTime = endTime;
        }

    }
}