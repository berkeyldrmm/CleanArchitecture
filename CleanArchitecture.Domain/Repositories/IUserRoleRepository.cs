using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Repositories;

public interface IUserRoleRepository : IGenericRepository<UserRole>
{
    Task<bool> CheckIfRoleExists(string userId, string roleId);
    Task<bool> CheckIfRoleExistsByName(string userId, string roleName);
}
