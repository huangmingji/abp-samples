using System;
using System.Threading.Tasks;
using Lemon.Account.Application.Contracts.Permissions;
using Lemon.Account.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Lemon.Account.HttpApi.Controllers
{
    [Route("api/user")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : AbpController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("")]
        // [Authorize(AccountPermissions.User.Create)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]CreateUserDto data)
        {
            var userDto = await _userService.GetByEmailAsync(data.Email);
            if (userDto != null)
            {
                return BadRequest();
            }

            userDto = await _userService.CreateAsync(data);
            if (userDto == null)
            {
                return NotFound();
            }

            return Ok(userDto);
        }


        [HttpGet("")]
        // [Authorize(AccountPermissions.User.Search)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResultDto<UserDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Get(int pageIndex, int pageSize, string name = null, 
            string account = null, string email = null, string mobile = null)
        {
            var result = _userService.Get(pageIndex, pageSize, name, account, email, mobile);
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        // [Authorize(AccountPermissions.User.Search)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var userDto = await _userService.GetAsync(id);
            return Ok(userDto);
        }

        [HttpPut("{id}")]
        // [Authorize(AccountPermissions.User.Update)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateUserDto data)
        {
            var userDto = await _userService.UpdateAsync(id, data);
            return Ok(userDto);
        }
        
        [HttpDelete("{id}")]
        // [Authorize(AccountPermissions.User.Delete)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
