using System.Collections.Generic;
using InGame.BestPractice.Roles.Dto;
using InGame.BestPractice.Users.Dto;

namespace InGame.BestPractice.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
