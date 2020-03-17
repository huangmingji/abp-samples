using System;
using System.Threading.Tasks;
using Lemon.UserCenter.Domain;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Lemon.UserCenter.Application
{
    public class UserService : ApplicationService, IUserService
    {
        private readonly IRepository<UserData, Guid> _repository;
        public UserService(IRepository<UserData, Guid> repository)
        {
            this._repository = repository;
        }

        public async Task<UserData> Create(UserData data)
        {
            return await _repository.InsertAsync(data);
        }
    }
}