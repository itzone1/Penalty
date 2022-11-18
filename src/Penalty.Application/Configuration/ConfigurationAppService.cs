using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Penalty.Configuration.Dto;

namespace Penalty.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : PenaltyAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
