using Abp.Authorization;
using InGame.BestPractice.Authorization.Roles;
using InGame.BestPractice.Authorization.Users;

namespace InGame.BestPractice.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
