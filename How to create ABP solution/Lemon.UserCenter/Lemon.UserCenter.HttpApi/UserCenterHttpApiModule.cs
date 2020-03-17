using Lemon.UserCenter.Application;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Lemon.UserCenter.HttpApi
{
    [DependsOn(typeof(AbpIdentityHttpApiModule),
    typeof(UserCenterApplicationModule))]
    public class UserCenterHttpApiModule : AbpModule
    {
        
    }
}