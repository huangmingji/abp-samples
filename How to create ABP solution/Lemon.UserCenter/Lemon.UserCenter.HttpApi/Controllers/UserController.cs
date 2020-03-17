using System.Threading.Tasks;
using Lemon.UserCenter.Application;
using Lemon.UserCenter.Domain;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Lemon.UserCenter.HttpApi.Controllers
{
    [Route("api/user")]
    public class UserController : AbpController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(UserData data)
        {
            var result = await _userService.Create(data);
            return Json(result);
        }
    }
}