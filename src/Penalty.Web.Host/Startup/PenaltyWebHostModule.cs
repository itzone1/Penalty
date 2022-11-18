using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Penalty.Configuration;

namespace Penalty.Web.Host.Startup
{
    [DependsOn(
       typeof(PenaltyWebCoreModule))]
    public class PenaltyWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PenaltyWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PenaltyWebHostModule).GetAssembly());
        }
    }
}
