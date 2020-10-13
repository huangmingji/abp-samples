using Lemon.Account.Domain.Role;
using Lemon.Account.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Lemon.Account.EntityFrameworkCore.MySQL
{    
    [ConnectionStringName("Default")]
    public class AccountDbContext: AbpDbContext<AccountDbContext>
    {
        public DbSet<UserData> UserData { get; set; }
        public DbSet<UserLogOn> UserLogOn { get; set; }
        public DbSet<RoleData> RoleData { get; set; }
        public DbSet<PermissionData> PermissionData { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        public AccountDbContext(DbContextOptions<AccountDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureLemonAccount();
            base.OnModelCreating(builder);
        }

    }
}