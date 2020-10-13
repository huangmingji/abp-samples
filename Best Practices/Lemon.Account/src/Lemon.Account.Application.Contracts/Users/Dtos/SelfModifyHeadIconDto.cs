using System;
using System.ComponentModel.DataAnnotations;

namespace Lemon.Account.Application
{
    public class SelfModifyHeadIconDto
    {
        [Required(ErrorMessage = "请上传头像图片")]
        public string HeadIcon { get; set; }
    }
}