using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lemon.Account.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Lemon.Account.Application.Contracts.Permissions;
using Microsoft.AspNetCore.Http;
using Volo.Abp.AspNetCore.Mvc;

namespace Lemon.Account.HttpApi.Controllers
{
    [Route("api/role")]
    [Produces("application/json")]
    [ApiController]
    public class RoleController : AbpController
    {
        private readonly IRoleService _roleService;
        public RoleController(
            IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("")]
        // [Authorize(AccountPermissions.Role.Create)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoleDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]CreateRoleDto data)
        {
            var result = await _roleService.CreateAsync(data);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        // [Authorize(AccountPermissions.Role.Delete)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _roleService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        // [Authorize(AccountPermissions.Role.Search)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RoleDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(Guid id)
        {
            var result = _roleService.Get(id);
            return Ok(result);
        }
        
        [HttpGet("")]
        // [Authorize(AccountPermissions.Role.Search)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RoleDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Get()
        {
            var result = _roleService.Get();
            return Ok(result);
        }

        [HttpPut("{id}")]
        // [Authorize(AccountPermissions.Role.Update)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoleDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody]UpdateRoleDto data)
        {
            var result = await _roleService.UpdateAsync(id, data);
            if (result == null) return BadRequest();
            return Ok(result);
        }
    }
}
