using System;
using System.ComponentModel.DataAnnotations;

namespace Lemon.Account.Application
{
    public class SelfModifyMobileDto
    {
        [Required(ErrorMessage = "请输入验证码")]
        public string Captcha { get; set; }
        
        [Required(ErrorMessage = "手机号码不能为空")]
        public string Mobile { get; set; }
    }
}