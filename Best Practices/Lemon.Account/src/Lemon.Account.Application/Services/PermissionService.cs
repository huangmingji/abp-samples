using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lemon.Account.Domain.Role;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Lemon.Account.Application
{
    public class PermissionService : ApplicationService, IPermissionService
    {
        private readonly IRepository<PermissionData, Guid> _permissionRepository;
        public PermissionService(IRepository<PermissionData, Guid> permissionRepository)
        {
            this._permissionRepository = permissionRepository;
        }

        public async Task<PermissionDto> CreateAsync(CreatePermissionDto data)
        {
            PermissionData permissionData = new PermissionData(
                GuidGenerator.Create(), 
                data.Name, 
                data.Permission, 
                data.ParentId);
            var result = await _permissionRepository.InsertAsync(permissionData);
            return ObjectMapper.Map<PermissionData, PermissionDto>(result);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _permissionRepository.DeleteAsync(x=> x.Id == id);
        }

        public async Task<PermissionDto> GetAsync(Guid id)
        {
            var data = await _permissionRepository.FindAsync(x => x.Id == id);
            return ObjectMapper.Map<PermissionData, PermissionDto>(data);
        }

        public async Task<List<PermissionDto>> GetAsync()
        {
            var data = await _permissionRepository.GetListAsync();
            return ObjectMapper.Map<List<PermissionData>, List<PermissionDto>>(data);
        }

        public async Task<PermissionDto> UpdateAsync(Guid id, UpdatePermissionDto data)
        {
            var permissionData = await _permissionRepository.FindAsync(x => x.Id == id);
            permissionData.Name = data.Name;
            permissionData.Permission = data.Permission;
            var result = await _permissionRepository.UpdateAsync(permissionData);
            return ObjectMapper.Map<PermissionData, PermissionDto>(result);
        }
    }
}
