using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Penalty.Controllers
{
    public abstract class PenaltyControllerBase: AbpController
    {
        protected PenaltyControllerBase()
        {
            LocalizationSourceName = PenaltyConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
