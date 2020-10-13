using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Lemon.Account.Application
{
    public interface IRoleService : IApplicationService
    {
        Task<RoleDto> CreateAsync(CreateRoleDto data);

        Task<RoleDto> UpdateAsync(Guid id, UpdateRoleDto data);

        List<RoleDto> Get();

        Task<RoleDto> Get(Guid id);

        Task DeleteAsync(Guid id);
    }
}