using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Lemon.Account.EntityFrameworkCore.DbMigrations
{
    [DependsOn(
        typeof(LemonAccountEntityFrameworkCoreModule))]
    public class LemonAccountEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AccountDbMigrationsDbContext>(options => {
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseNpgsql();
            });

            #region 自动迁移数据库

            context.Services.BuildServiceProvider().GetService<AccountDbMigrationsDbContext>().Database.Migrate();

            #endregion 自动迁移数据库
        }
    }
}