using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Lemon.Account.Application
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(CreateUserDto data);
        
        Task<UserDto> GetAsync(Guid id);
        
        PagedResultDto<UserDto> Get(int pageIndex, 
            int pageSize, string name = null, string account = null, 
            string email = null, string mobile= null);

        Task DeleteAsync(Guid id);

        Task<UserDto> GetByMobileAsync(string mobile);
        
        Task<UserDto> GetByEmailAsync(string email);

        Task<UserDto> GetByAccountAsync(string account);

        Task<UserDto> UpdateMobileAsync(SelfModifyMobileDto data);
        
        Task<UserDto> UpdateEmailAsync(SelfModifyEmailDto data);
        
        Task<UserDto> UpdateHeadIconAsync(SelfModifyHeadIconDto data);
        
        Task<UserDto> UpdatePasswordAsync(SelfModifyPasswordDto data);
        
        Task<UserDto> VerifyAsync(VerifyPasswordDto data);

        Task<UserDto> UpdateAsync(Guid id, UpdateUserDto data);

    }
}