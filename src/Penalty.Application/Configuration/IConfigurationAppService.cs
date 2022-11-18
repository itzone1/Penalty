using System.Threading.Tasks;
using Penalty.Configuration.Dto;

namespace Penalty.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
