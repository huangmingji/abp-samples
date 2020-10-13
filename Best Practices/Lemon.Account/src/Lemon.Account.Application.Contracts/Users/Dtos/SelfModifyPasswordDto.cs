using System;
using System.ComponentModel.DataAnnotations;

namespace Lemon.Account.Application
{
    public class SelfModifyPasswordDto
    {
        [Required(ErrorMessage = "旧密码不能为空")]
        public string OldPassword { get; set; }
        
        [Required(ErrorMessage = "新密码不能为空")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",
            ErrorMessage = "请输入至少8个字符，由大小写字母、数字组合而成的密码")]
        public string Password { get; set; }
    }
}