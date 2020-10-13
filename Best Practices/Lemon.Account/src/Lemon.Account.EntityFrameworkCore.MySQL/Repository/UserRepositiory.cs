using System;
using System.Linq;
using Lemon.Account.Domain.Repository;
using System.Threading.Tasks;
using Lemon.Account.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lemon.Account.EntityFrameworkCore.Repository
{
    public class UserRepository : EfCoreRepository<MySQL.AccountDbContext, UserData, Guid>, IUserRepository
    {
        public UserRepository(IDbContextProvider<MySQL.AccountDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<UserData> GetAsync(Guid id)
        {
            return await WithDetails()
                .FirstAsync(x=> x.Id == id);
        }

        public async Task<UserData> GetAsync(string name)
        {
            return await WithDetails()
                .FirstOrDefaultAsync(x=> x.Account == name 
                                         || x.Mobile == name
                                         || x.Email == name);
        }

        public override IQueryable<UserData> WithDetails()
        {
            return GetQueryable().Include(x => x.UserLogOn)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.RoleData)
                .ThenInclude(x => x.Permissions);
        }
    }
}