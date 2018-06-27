using Abp.AspNetCore.Mvc.ViewComponents;

namespace InGame.BestPractice.Web.Views
{
    public abstract class BestPracticeViewComponent : AbpViewComponent
    {
        protected BestPracticeViewComponent()
        {
            LocalizationSourceName = BestPracticeConsts.LocalizationSourceName;
        }
    }
}
