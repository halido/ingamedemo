using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using InGame.BestPractice.Configuration;

namespace InGame.BestPractice.Web.Host.Startup
{
    [DependsOn(
       typeof(BestPracticeWebCoreModule))]
    public class BestPracticeWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BestPracticeWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BestPracticeWebHostModule).GetAssembly());
        }
    }
}
