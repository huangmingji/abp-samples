using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Lemon.Account.Domain.Users;
using Volo.Abp.Domain.Repositories;
using Lemon.Account.Domain.Repository;
using Volo.Abp.Application.Dtos;

namespace Lemon.Account.Application
{
    public class UserService : ApplicationService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRepository<UserRole, Guid> _userRoleRepository;

        public UserService(
            IUserRepository userRepository,
            IRepository<UserRole, Guid> userRoleRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        public async Task<UserDto> CreateAsync(CreateUserDto data)
        {
            var userData = new UserData(GuidGenerator.Create(), data.Password, data.UserName, data.Email);
            await _userRepository.InsertAsync(userData);
            return ObjectMapper.Map<UserData, UserDto>(userData);
        }

        public async Task<UserDto> GetAsync(Guid id)
        {
            var userData = await _userRepository.GetAsync(id);
            return ObjectMapper.Map<UserData, UserDto>(userData);
        }

        public PagedResultDto<UserDto> Get(int pageIndex, int pageSize, string name = null, 
            string account = null, string email = null, string mobile = null)
        {
            var queryable = _userRepository.WithDetails();
            if (!name.IsNullOrWhiteSpace())
            {
                queryable = queryable.Where(x => x.NickName == name);
            }

            if (!account.IsNullOrWhiteSpace())
            {
                queryable = queryable.Where(x => x.Account == account);
            }

            if (!email.IsNullOrWhiteSpace())
            {
                queryable = queryable.Where(x => x.Email == email);
            }
            
            if (!mobile.IsNullOrWhiteSpace())
            {
                queryable = queryable.Where(x => x.Mobile == mobile);
            }

            int total = queryable.Count();
            var data = queryable.PageBy((pageIndex - 1) * pageSize, pageSize).ToList();
            var result = ObjectMapper.Map<List<UserData>, List<UserDto>>(data);
            return new PagedResultDto<UserDto>()
            {
                TotalCount = total,
                Items = result
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(x=> x.Id == id);
        }

        public async Task<UserDto> GetByMobileAsync(string mobile)
        {
            var userData = await _userRepository.GetAsync(x=> x.Mobile == mobile);
            return ObjectMapper.Map<UserData, UserDto>(userData);
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var userData = await _userRepository.GetAsync(x=> x.Email == email);
            return ObjectMapper.Map<UserData, UserDto>(userData);
        }

        public async Task<UserDto> GetByAccountAsync(string account)
        {
            var userData = await _userRepository.GetAsync(x=> x.Account == account);
            return ObjectMapper.Map<UserData, UserDto>(userData);
        }

        public async Task<UserDto> UpdateMobileAsync(SelfModifyMobileDto data)
        {
            var userData = await _userRepository.GetAsync(x => x.Id == CurrentUser.Id);
            userData.Mobile = data.Mobile;
            var result = await _userRepository.UpdateAsync(userData);
            return ObjectMapper.Map<UserData, UserDto>(result);
        }

        public async Task<UserDto> UpdateEmailAsync(SelfModifyEmailDto data)
        {
            var userData = await _userRepository.GetAsync(x => x.Id == CurrentUser.Id);
            userData.Email = data.Email;
            var result = await _userRepository.UpdateAsync(userData);
            return ObjectMapper.Map<UserData, UserDto>(result);
        }

        public async Task<UserDto> UpdateHeadIconAsync(SelfModifyHeadIconDto data)
        {
            var userData = await _userRepository.GetAsync(x => x.Id == CurrentUser.Id);
            userData.HeadIcon = data.HeadIcon;
            var result = await _userRepository.UpdateAsync(userData);
            return ObjectMapper.Map<UserData, UserDto>(result);
        }

        public async Task<UserDto> UpdatePasswordAsync(SelfModifyPasswordDto data)
        { 
            var userData = _userRepository.WithDetails().FirstOrDefault(x => x.Id == CurrentUser.Id);
            if(userData == null) return null;

            if (!userData.VerifyPassword(data.OldPassword))
            {
                return null;
            }

            userData.UpdatePassword(data.Password);
            var result = await _userRepository.UpdateAsync(userData);
            return ObjectMapper.Map<UserData, UserDto>(result);
        }

        public async Task<UserDto> VerifyAsync(VerifyPasswordDto data)
        {
            UserData userData = await _userRepository.GetAsync(data.Name);
            if (userData == null) return null;

            if (userData.VerifyPassword(data.Password))
            {
                return ObjectMapper.Map<UserData, UserDto>(userData);
            }
            return null;
        }

        public async Task<UserDto> UpdateAsync(Guid id, UpdateUserDto data)
        {
            UserData userData = await _userRepository.GetAsync(id);
            userData.NickName = data.Name;
            userData.Account = data.Account;
            userData.Email = data.Email;
            userData.Mobile = data.Mobile;
            userData.UpdatePassword(data.Password);
            
            userData.UserRoles.Clear();
            foreach (var item in data.RoleIds)
            {
                userData.AddRole(GuidGenerator.Create(), item);
            }
            
            var result = await _userRepository.UpdateAsync(userData);
            return ObjectMapper.Map<UserData, UserDto>(userData);
        }
    }
}
