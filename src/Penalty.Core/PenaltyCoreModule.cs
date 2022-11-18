using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Threading.BackgroundWorkers;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using Penalty.Authorization.Roles;
using Penalty.Authorization.Users;
using Penalty.Configuration;
using Penalty.Localization;
using Penalty.MultiTenancy;
using Penalty.Penalty.ODDSApiMatches.Services;
using Penalty.Timing;

namespace Penalty
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class PenaltyCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            PenaltyLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
           // Configuration.MultiTenancy.IsEnabled = PenaltyConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
            
            Configuration.Localization.Languages.Add(new LanguageInfo("fa", "فارسی", "famfamfam-flags ir"));
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = PenaltyConsts.DefaultPassPhrase;
            SimpleStringCipher.DefaultPassPhrase = PenaltyConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PenaltyCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
