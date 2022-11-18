using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Threading.BackgroundWorkers;
using Penalty.Authorization;

namespace Penalty
{
    [DependsOn(
        typeof(PenaltyCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class PenaltyApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<PenaltyAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(PenaltyApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
