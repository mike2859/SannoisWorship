using Microsoft.AspNetCore.Identity;
using SannoisWorship.Application.DTOs;

namespace SannoisWorship.Application.Interfaces;

public interface IUserManagementService
{
    IEnumerable<string> GetUserRoles();

    Task<List<string>> GetRolesAsync();
    Task<IdentityResult> CreateUserAsync(CreateUserModel userModel);

    Task<List<UserWithRolesDto>> GetUsersWithRolesAsync();

    Task<IdentityResult> AddRoleToUserAsync(IdentityUser userModel, string role);

    Task<bool> AddRoleAsync(string roleName);
}
