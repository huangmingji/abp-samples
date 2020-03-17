using Volo.Abp.Modularity;
using Volo.Abp.Identity;

namespace Lemon.UserCenter.Application
{
    [DependsOn(typeof(AbpIdentityApplicationModule))]
    public class UserCenterApplicationModule : AbpModule
    {
        
    }
}