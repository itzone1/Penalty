using System.Threading.Tasks;
using Abp.Application.Services;
using Penalty.Sessions.Dto;

namespace Penalty.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
