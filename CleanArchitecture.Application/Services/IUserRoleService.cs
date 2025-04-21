using CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Services;

public interface IUserRoleService
{
    Task<MessageResponse> CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken);
    Task<bool> CheckIfRoleExists(CreateUserRoleCommand request);
    Task<bool> CheckIfRoleExistsByName(string userId, string roleName);
}
