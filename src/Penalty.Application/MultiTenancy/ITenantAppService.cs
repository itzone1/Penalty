using Abp.Application.Services;
using Penalty.MultiTenancy.Dto;

namespace Penalty.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

