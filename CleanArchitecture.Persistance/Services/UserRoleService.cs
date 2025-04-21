using CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;

namespace CleanArchitecture.Persistance.Services;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _userRoleRepostiory;
    private readonly IUnitOfWork _unitOfWork;
    public UserRoleService(IUserRoleRepository userRoleRepostiory, IUnitOfWork unitOfWork)
    {
        _userRoleRepostiory = userRoleRepostiory;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> CheckIfRoleExists(CreateUserRoleCommand request)
    {
        return await _userRoleRepostiory.CheckIfRoleExists(request.UserId, request.RoleId);
    }

    public async Task<bool> CheckIfRoleExistsByName(string userId, string roleName)
    {
        return await _userRoleRepostiory.CheckIfRoleExistsByName(userId, roleName);
    }

    public async Task<MessageResponse> CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        bool exists = await CheckIfRoleExists(request);
        if (!exists)
        {
            UserRole userRole = new()
            {
                UserId = request.UserId,
                RoleId = request.RoleId
            };

            _ = await _userRoleRepostiory.AddAsync(userRole, cancellationToken);
            _ = await _unitOfWork.SaveChangesAsync();

            return new MessageResponse("Role has been assigned to the user successfully!");
        }

        throw new Exception("Role has already been assigned to the user!");
    }
}
