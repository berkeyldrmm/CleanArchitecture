using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace CleanArchitecture.Infrastructure.Authorization;

public class RoleValidationFilter : IAsyncAuthorizationFilter
{
    public string _role;
    private readonly IUserRoleService _userRoleService;
    public RoleValidationFilter(string role, IUserRoleService userRoleService)
    {
        _role = role;
        _userRoleService = userRoleService;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        Claim userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if(userIdClaim == null)
        {
            context.Result = new UnauthorizedResult();
        }

        bool exists = await _userRoleService.CheckIfRoleExistsByName(userIdClaim.Value, _role);
        if (!exists)
        {
            context.Result = new ForbidResult();
        }
    }
}
