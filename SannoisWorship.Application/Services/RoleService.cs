using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace SannoisWorship.Application.Services;

public class RoleService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RoleService(IHttpContextAccessor httpContextAccessor)
    {
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
}
