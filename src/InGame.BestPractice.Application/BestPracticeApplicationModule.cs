using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using InGame.BestPractice.Authorization;

namespace InGame.BestPractice
{
    [DependsOn(
        typeof(BestPracticeCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BestPracticeApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BestPracticeAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BestPracticeApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
