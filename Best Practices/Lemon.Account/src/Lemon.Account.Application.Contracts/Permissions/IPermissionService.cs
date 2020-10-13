using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Lemon.Account.Application
{
    public interface IPermissionService : IApplicationService
    {
        Task<PermissionDto> CreateAsync(CreatePermissionDto data);

        Task<PermissionDto> UpdateAsync(Guid id, UpdatePermissionDto data);

        Task<PermissionDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<List<PermissionDto>> GetAsync();
    }
}