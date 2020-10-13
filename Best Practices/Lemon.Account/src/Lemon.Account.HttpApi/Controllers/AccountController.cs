using System;
using System.Threading.Tasks;
using Lemon.Account.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Lemon.Account.HttpApi.Controllers
{
    [Route("api/account")]
    [Produces("application/json")]
    [ApiController]
    public class AccountController : AbpController
    {
        private readonly IUserService _userService;

        public AccountController(
            IUserService userService)
        {
            this._userService = userService;
        }
        
        /// <summary>
        /// 账号密码验证，200：验证成功；400：账号密码为空；404：验证失败
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("verify")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> VerifyPasswordAsync([FromBody]VerifyPasswordDto data)
        {
            var result = await _userService.VerifyPasswordAsync(data);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        /// <summary>
        /// 账号注册，200：账号注册成功并返回账号信息；400：注册信息有误
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAsync([FromBody]CreateUserDto data)
        {
            var userDto = await _userService.GetByEmailAsync(data.Email);
            if (userDto != null)
            {
                return BadRequest();
            }

            var result = await _userService.CreateAsync(data);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        
        [HttpPut("update_mobile")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SelfModifyMobileAsync([FromBody]SelfModifyMobileDto data)
        {
            var userDto = await _userService.SelfModifyMobileAsync(data);
            return Ok(userDto);
        }

        [HttpPut("update_head_icon")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUserHeadIconAsync([FromBody]SelfModifyHeadIconDto data)
        {
            var userDto = await _userService.UpdateUserHeadIconAsync(data);
            return Ok(userDto);
        }

        [HttpPut("modify_password")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SelfModifyPasswordAsync([FromBody]SelfModifyPasswordDto data)
        {
            var userDto = await _userService.SelfModifyPasswordAsync(data);
            return Ok(userDto);
        }
    }
}