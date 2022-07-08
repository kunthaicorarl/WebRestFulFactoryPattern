using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace WebRestFulFactoryPattern.Permission
{
internal class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
        
    public PermissionAuthorizationHandler()
    {

    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
            await Task.Run(() =>
            {
                if (context.User == null)
                {
                    return;
                }
                var permissionss = context.User.Claims.Where(x => x.Type == "Permission" &&
                                                                x.Value == requirement.Permission &&
                                                                x.Issuer == "LOCAL AUTHORITY");
                if (permissionss.Any())
                {
                    context.Succeed(requirement);
                    return;
                }
            });
    }
}
}