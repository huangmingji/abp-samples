using Lemon.UserCenter.Domain;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Lemon.UserCenter.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class UserCenterDbContext : AbpDbContext<UserCenterDbContext>
    {
        public DbSet<UserData> UserData { get; set; }
        
        public UserCenterDbContext(DbContextOptions<UserCenterDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}