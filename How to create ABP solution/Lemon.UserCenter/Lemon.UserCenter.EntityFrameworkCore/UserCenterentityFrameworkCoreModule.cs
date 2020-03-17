using Lemon.UserCenter.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.Modularity;

namespace Lemon.UserCenter.EntityFrameworkCore
{
    [DependsOn(typeof(UserCenterDomainModule),
        typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCorePostgreSqlModule))]
    public class UserCenterentityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<UserCenterDbContext>(options => {
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(ctx =>
                {
                    if (ctx.ExistingConnection != null)
                    {
                        ctx.DbContextOptions.UseNpgsql(ctx.ExistingConnection);
                    }
                    else
                    {
                        ctx.DbContextOptions.UseNpgsql(ctx.ConnectionString);
                    }
                });
            });

            #region 自动迁移数据库

            context.Services.BuildServiceProvider().GetService<UserCenterDbContext>().Database.Migrate();

            #endregion 自动迁移数据库
        }
    }
}