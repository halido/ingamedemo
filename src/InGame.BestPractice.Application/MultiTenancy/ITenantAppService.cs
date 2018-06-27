using Abp.Application.Services;
using Abp.Application.Services.Dto;
using InGame.BestPractice.MultiTenancy.Dto;

namespace InGame.BestPractice.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
