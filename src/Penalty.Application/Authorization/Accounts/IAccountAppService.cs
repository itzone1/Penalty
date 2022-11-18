using System.Threading.Tasks;
using Abp.Application.Services;
using Penalty.Authorization.Accounts.Dto;

namespace Penalty.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
