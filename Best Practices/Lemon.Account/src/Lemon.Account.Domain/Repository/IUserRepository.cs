using System;
using System.Threading.Tasks;
using Lemon.Account.Domain.Users;
using Volo.Abp.Domain.Repositories;

namespace Lemon.Account.Domain.Repository
{
    public interface IUserRepository : IRepository<UserData, Guid>
    {
        Task<UserData> GetAsync(Guid id);
        
        Task<UserData> GetAsync(string name);

    }
}