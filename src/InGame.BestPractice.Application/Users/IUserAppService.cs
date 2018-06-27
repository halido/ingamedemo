using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using InGame.BestPractice.Roles.Dto;
using InGame.BestPractice.Users.Dto;

namespace InGame.BestPractice.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
