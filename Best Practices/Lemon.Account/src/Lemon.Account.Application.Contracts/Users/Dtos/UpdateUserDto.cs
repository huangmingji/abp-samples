using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lemon.Account.Application
{
    public class UpdateUserDto
    {
        [Required(ErrorMessage = "姓名不能为空")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "账号不能为空")]
        public string Account { get; set; }
        
        [Required(ErrorMessage = "邮箱地址不能为空")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "手机号码不能为空")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",
            ErrorMessage = "请输入至少8个字符，由大小写字母、数字组合而成的密码")]
        public string Password { get; set; }
        
        public List<Guid> RoleIds { get; set; } = new List<Guid>();

    }
}