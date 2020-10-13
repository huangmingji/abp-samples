using Lemon.Account.Application.Contracts;
using Lemon.Account.Application.Contracts.Permissions;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Lemon.Account.HttpApi
{
    [DependsOn(
        typeof(LemonAccountApplicationContractsModule),
            typeof(AbpAspNetCoreMvcModule)
    )]
    public class LemonAccountHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAuthorization(options =>
            {
                foreach (var item in AccountPermissions.GetAll())
                {
                    options.AddPolicy(item, policy =>
                    {
                        policy.RequireClaim("permisson", item);
                    });
                }
            });
        }
    }
}