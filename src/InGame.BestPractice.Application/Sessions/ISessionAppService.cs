using System.Threading.Tasks;
using Abp.Application.Services;
using InGame.BestPractice.Sessions.Dto;

namespace InGame.BestPractice.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
