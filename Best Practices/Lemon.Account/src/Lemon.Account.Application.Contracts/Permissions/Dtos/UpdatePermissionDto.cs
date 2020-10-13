using System;
using System.ComponentModel.DataAnnotations;

namespace Lemon.Account.Application
{
    public class UpdatePermissionDto
    {
        
        [Required(ErrorMessage = "名称不能为空")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "权限key不能为空")]
        public string Permission { get; set; }
    }
}