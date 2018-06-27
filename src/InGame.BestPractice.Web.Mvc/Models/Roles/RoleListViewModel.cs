using System.Collections.Generic;
using InGame.BestPractice.Roles.Dto;

namespace InGame.BestPractice.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
