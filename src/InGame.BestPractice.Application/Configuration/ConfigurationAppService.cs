using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using InGame.BestPractice.Configuration.Dto;

namespace InGame.BestPractice.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BestPracticeAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
