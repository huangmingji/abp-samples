using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lemon.Account.Domain.Role;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Lemon.Account.Application
{
    public class RoleService : ApplicationService, IRoleService
    {
        private readonly ILogger<RoleService> _logger;
        private readonly IRepository<RoleData, Guid> _roleRepository;
        public RoleService(IRepository<RoleData, Guid> roleRepository,
        ILogger<RoleService> logger)
        {
            this._logger = logger;
            this._roleRepository = roleRepository;
        }

        public async Task<RoleDto> CreateAsync(CreateRoleDto data)
        {
            var roleData = new RoleData(GuidGenerator.Create(), data.Name);
            var result = await _roleRepository.InsertAsync(roleData);
            return ObjectMapper.Map<RoleData, RoleDto>(result);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _roleRepository.DeleteAsync(x=> x.Id == id);
        }

        public List<RoleDto> Get()
        {
            var data = _roleRepository.WithDetails().ToList();
            return ObjectMapper.Map<List<RoleData>, List<RoleDto>>(data);
        }

        public async Task<RoleDto> Get(Guid id)
        {
            var data = await _roleRepository.GetAsync(x => x.Id == id);
            return ObjectMapper.Map<RoleData, RoleDto>(data);       
        }

        public async Task<RoleDto> UpdateAsync(Guid id ,UpdateRoleDto data)
        {
            var roleData = await _roleRepository.GetAsync(id);
            roleData.Name = data.Name;
            var result = await _roleRepository.UpdateAsync(roleData);
            return ObjectMapper.Map<RoleData, RoleDto>(roleData);
        }
    }
}
