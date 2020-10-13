using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lemon.Account.Application
{
    public class CreatePermissionDto
    {
        public Guid? ParentId { get; set; }
        
        [Required(ErrorMessage = "名称不能为空")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "权限key不能为空")]
        public string Permission { get; set; }
    }
}