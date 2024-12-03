using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SannoisWorship.Application.DTOs;
using SannoisWorship.Application.Interfaces;
using System.Security.Claims;

namespace SannoisWorship.Application.Services;

public class UserManagementService : IUserManagementService
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserManagementService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _httpContextAccessor = httpContextAccessor;
    }
    public IEnumerable<string> GetUserRoles()
    {
        var user = _httpContextAccessor.HttpContext?.User;

        if (user?.Identity?.IsAuthenticated ?? false)
        {
            return user.FindAll(ClaimTypes.Role).Select(c => c.Value);
        }

        return Enumerable.Empty<string>();
    }
    public async Task<List<string>> GetRolesAsync()
    {
        return await Task.FromResult(_roleManager.Roles.Select(r => r.Name).ToList());
    }

    public async Task<IdentityResult> CreateUserAsync(CreateUserModel userModel)
    {
        var user = new IdentityUser { UserName = userModel.UserName, Email = userModel.Email};
        var result = await _userManager.CreateAsync(user, userModel.Password);
        if (result.Succeeded)
        {
            await AddRoleToUserAsync(user, userModel.Role);
        }
        return result;
    }

    public async Task<IdentityResult> AddRoleToUserAsync(IdentityUser userModel, string role)
    {

        return await _userManager.AddToRoleAsync(userModel, role);

    }

  
    public async Task<bool> AddRoleAsync(string roleName)
    {
        // Vérifie si le rôle existe déjà
        if (await _roleManager.RoleExistsAsync(roleName))
        {
            return false; // Retourne false si le rôle existe déjà
        }

        // Crée le rôle
        var result = await _roleManager.CreateAsync(new IdentityRole(roleName));

        // Retourne true si la création a réussi, sinon false
        return result.Succeeded;
    }

    public async Task<List<UserWithRolesDto>> GetUsersWithRolesAsync()
    {
        var users = await _userManager.Users.ToListAsync();
        var usersWithRoles = new List<UserWithRolesDto>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            usersWithRoles.Add(new UserWithRolesDto
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Roles = roles.ToList()
            });
        }

        return usersWithRoles;
    }


}
