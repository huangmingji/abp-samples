using System;
using AutoMapper;
using Lemon.Account.Domain.Role;
using Lemon.Account.Domain.Users;

namespace Lemon.Account.Application
{
    public class LemonAccountApplicationAutoMapperProfile : Profile
    {
        public LemonAccountApplicationAutoMapperProfile()
        {
            CreateUserDataMappings();
        }
        
        private void CreateUserDataMappings()
        {
            CreateMap<UserData, UserDto>();
            CreateMap<UserLogOn, UserLogOnDto>();
            CreateMap<UserRole, UserRoleDto>();
            CreateMap<RoleData, RoleDto>();
            CreateMap<RolePermissionData, RolePermissionDto>();
            CreateMap<PermissionData, PermissionDto>();
        }
    }
}