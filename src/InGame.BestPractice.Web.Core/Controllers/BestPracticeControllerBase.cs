using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace InGame.BestPractice.Controllers
{
    public abstract class BestPracticeControllerBase: AbpController
    {
        protected BestPracticeControllerBase()
        {
            LocalizationSourceName = BestPracticeConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
