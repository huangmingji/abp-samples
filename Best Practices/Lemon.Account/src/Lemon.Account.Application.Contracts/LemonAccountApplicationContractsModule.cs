using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Lemon.Account.Application.Contracts
{
    [DependsOn(typeof(AbpDddApplicationContractsModule))]
    public class LemonAccountApplicationContractsModule : AbpModule
    {
        
    }
}