using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace InGame.BestPractice.Web.Views
{
    public abstract class BestPracticeRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected BestPracticeRazorPage()
        {
            LocalizationSourceName = BestPracticeConsts.LocalizationSourceName;
        }
    }
}
