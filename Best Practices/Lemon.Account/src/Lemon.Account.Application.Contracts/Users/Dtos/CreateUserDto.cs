using System.ComponentModel.DataAnnotations;

namespace Lemon.Account.Application
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "邮箱地址不能为空")]
        [EmailAddress(ErrorMessage = "请输入一个邮箱地址")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "密码不能为空")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",
            ErrorMessage = "请输入至少8个字符，由大小写字母、数字组合而成的密码")]
        public string Password { get; set; }
    }
}