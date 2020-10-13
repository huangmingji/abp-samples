using System.ComponentModel.DataAnnotations;

namespace Lemon.Account.Application
{
    public class VerifyPasswordDto
    {
        [Required(ErrorMessage = "账号密码不能为空")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "账号密码不能为空")]
        public string Password { get; set; }
    }
}