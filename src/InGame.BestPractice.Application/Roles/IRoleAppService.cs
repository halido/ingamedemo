using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using InGame.BestPractice.Roles.Dto;

namespace InGame.BestPractice.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
