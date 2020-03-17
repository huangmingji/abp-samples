using Lemon.UserCenter.Domain;
using Lemon.UserCenter.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Lemon.UserCenter.HttpApi.Hosting
{
    [DependsOn(typeof(UserCenterHttpApiModule),
                typeof(UserCenterDomainModule),
                typeof(UserCenterentityFrameworkCoreModule),
                typeof(AbpAspNetCoreMvcModule),
                typeof(AbpAutofacModule))]
    public class UserCenterHttpApiHostingModule: AbpModule
    {
        public override void OnApplicationInitialization(
            ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseMvcWithDefaultRouteAndArea();
        }
    }
}