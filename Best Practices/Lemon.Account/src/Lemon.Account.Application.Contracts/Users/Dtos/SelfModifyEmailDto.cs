using System;
using System.ComponentModel.DataAnnotations;

namespace Lemon.Account.Application
{
    public class SelfModifyEmailDto
    {
        [Required(ErrorMessage = "请输入验证码")]
        public string Captcha { get; set; }
        
        [Required(ErrorMessage = "请输入邮箱地址")]
        [EmailAddress]
        public string Email { get; set; }
    }
}