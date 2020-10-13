using Lemon.Account.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Users;

namespace Lemon.Account.Application
{
    [DependsOn(
        typeof(LemonAccountApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
    )]
    public class LemonAccountApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            context.Services.AddAutoMapperObjectMapper<LemonAccountApplicationModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<LemonAccountApplicationAutoMapperProfile>(validate: true);
            });
        }
    }
}