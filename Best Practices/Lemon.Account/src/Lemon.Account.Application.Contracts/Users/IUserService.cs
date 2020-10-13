using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Lemon.Account.Application
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(CreateUserDto data);
        
        Task<UserDto> GetAsync(Guid userId);
        
        PagedResultDto<UserDto> GetByPage(int pageIndex, 
            int pageSize, string name = null, string account = null, 
            string email = null, string mobile= null);

        Task DeleteAsync(Guid id);

        Task<UserDto> GetByMobileAsync(string mobile);
        
        Task<UserDto> GetByEmailAsync(string email);

        Task<UserDto> GetByAccountAsync(string account);

        Task<UserDto> SelfModifyMobileAsync(SelfModifyMobileDto data);
        
        Task<UserDto> SelfModifyEmailAsync(SelfModifyEmailDto data);
        
        Task<UserDto> UpdateUserHeadIconAsync(SelfModifyHeadIconDto data);

        Task<UserDto> UpdateUserPasswordAsync(UpdateUserPasswordDto data);
        
        Task<UserDto> SelfModifyPasswordAsync(SelfModifyPasswordDto data);

        Task<UserDto> UpdateUserRoleAsync(UpdateUserRoleDto data);
        
        Task<UserDto> VerifyPasswordAsync(VerifyPasswordDto data);

        Task<UserDto> UpdateUserAsync(Guid id, UpdateUserDto data);

    }
}