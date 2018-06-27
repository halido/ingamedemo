using System.Threading.Tasks;
using InGame.BestPractice.Configuration.Dto;

namespace InGame.BestPractice.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
