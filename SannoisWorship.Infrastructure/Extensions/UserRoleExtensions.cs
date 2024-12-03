using SannoisWorship.Infrastructure.Enums;

namespace SannoisWorship.Infrastructure.Extensions;

public static class UserRoleExtensions
{
    public static string GetLabel(this UserRole role) =>
    role switch
    {
        UserRole.Admin => "Admin",
        UserRole.Visiteur => "Visiteur",
        UserRole.Musicien => "Musicien",
        UserRole.Chantre => "Chantre",
        UserRole.Compositeur => "Compositeur",
        _ => "Unknown"
    };
}
