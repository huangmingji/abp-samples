using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lemon.Account.Application
{
    public class UpdateUserRoleDto
    {
        [Required(ErrorMessage = "用户主键为空")]
        public Guid UserId { get; set; }

        public List<Guid> RoleIds { get; set; } = new List<Guid>();
    }
}