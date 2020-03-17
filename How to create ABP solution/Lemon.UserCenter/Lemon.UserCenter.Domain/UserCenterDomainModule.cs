using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Lemon.UserCenter.Domain
{
    [DependsOn(typeof(AbpIdentityDomainModule))]
    public class UserCenterDomainModule : AbpModule
    {
        
    }
}