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
    [Route("api/permission")]
    [Produces("application/json")]
    [ApiController]
    public class PermissionController : AbpController
    {
        private readonly IPermissionService _permissionService;
        public PermissionController(
            IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpPost("")]
        // [Authorize(AccountPermissions.Permission.Create)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PermissionDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]CreatePermissionDto data)
        {
            var result = await _permissionService.CreateAsync(data);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        // [Authorize(AccountPermissions.Permission.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PermissionDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var data = await _permissionService.GetAsync(id);
            if(data == null)
            {
                return NotFound();
            }
            await _permissionService.DeleteAsync(id);
            return Ok(data);
        }

        [HttpGet("{id}")]
        // [Authorize(AccountPermissions.Permission.Search)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PermissionDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _permissionService.GetAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("")]
        // [Authorize(AccountPermissions.Permission.Search)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PermissionDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _permissionService.GetAsync();
            return Ok(result);
        }

        [HttpPut("{id}")]
        // [Authorize(AccountPermissions.Permission.Update)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PermissionDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody]UpdatePermissionDto data)
        {
            var permission = await _permissionService.GetAsync(id);
            if(permission == null)
            {
                return NotFound();
            }
            var result = await _permissionService.UpdateAsync(id, data);
            if (result == null) return BadRequest();
            return Ok(result);
        }
    }
}