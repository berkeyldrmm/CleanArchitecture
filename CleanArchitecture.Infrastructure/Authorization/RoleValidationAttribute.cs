using CleanArchitecture.Application.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.Authorization;

public class RoleValidationAttribute : Attribute, IFilterFactory
{
    public string RoleName { get; set; }

    public RoleValidationAttribute(string roleName)
    {
        RoleName = roleName;
    }

    public bool IsReusable => false;

    public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    {
        var userRoleService = serviceProvider.GetRequiredService<IUserRoleService>();
        return new RoleValidationFilter(RoleName, userRoleService);
    }
}
