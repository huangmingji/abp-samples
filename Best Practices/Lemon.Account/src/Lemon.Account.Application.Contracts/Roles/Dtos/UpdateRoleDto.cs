using System;
using System.ComponentModel.DataAnnotations;

namespace Lemon.Account.Application
{
    public class UpdateRoleDto
    {
        [Required(ErrorMessage = "名称不能为空")]
        public string Name { get; set; }
    }
}