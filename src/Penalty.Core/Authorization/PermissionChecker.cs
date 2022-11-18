using Abp.Authorization;
using Penalty.Authorization.Roles;
using Penalty.Authorization.Users;

namespace Penalty.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
