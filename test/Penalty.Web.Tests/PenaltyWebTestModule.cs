using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Penalty.EntityFrameworkCore;
using Penalty.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Penalty.Web.Tests
{
    [DependsOn(
        typeof(PenaltyWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class PenaltyWebTestModule : AbpModule
    {
        public PenaltyWebTestModule(PenaltyEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PenaltyWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(PenaltyWebMvcModule).Assembly);
        }
    }
}