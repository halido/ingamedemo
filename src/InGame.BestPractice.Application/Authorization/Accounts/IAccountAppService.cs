using System.Threading.Tasks;
using Abp.Application.Services;
using InGame.BestPractice.Authorization.Accounts.Dto;

namespace InGame.BestPractice.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
