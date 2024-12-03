using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SannoisWorship.Infrastructure.Data;

namespace SannoisWorship.Infrastructure.Extensions;

public static class DatabaseExtentions
{
    public static async Task InitialiseDatabaseAsync(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        // var logger = scope.ServiceProvider.GetRequiredService<ILogger<DatabaseExtensions>>();
        try
        {
            var context = services.GetRequiredService<SannoisWorshipDbContext>();
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            // Appliquer les migrations
            // logger.LogInformation("Applying database migrations...");
            await context.Database.MigrateAsync();

            // Seed des rôles et utilisateur admin
            await SeedRolesAsync(roleManager);
            await SeedAdminUserAsync(userManager, roleManager);
            // logger.LogInformation("Database initialization completed successfully.");
        }
        catch (Exception ex)
        {
            //logger.LogError(ex, "An error occurred during database initialization.");
            // Gérer les erreurs d'initialisation
            Console.WriteLine($"Erreur lors de l'initialisation de la base de données : {ex.Message}");
        }
    }
    public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        var roleNames = new[] { UserRoleExtensions.GetLabel(Enums.UserRole.Admin),
            UserRoleExtensions.GetLabel(Enums.UserRole.Musicien),
            UserRoleExtensions.GetLabel(Enums.UserRole.Chantre),
            UserRoleExtensions.GetLabel(Enums.UserRole.Compositeur),
            UserRoleExtensions.GetLabel(Enums.UserRole.Visiteur) };

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }


    public static async Task SeedAdminUserAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Créer un utilisateur admin par défaut si il n'existe pas
        var adminUser = await userManager.FindByEmailAsync("admin@sannois-worship.com");
        if (adminUser == null)
        {
            adminUser = new IdentityUser
            {
                UserName = "admin",
                Email = "admin@sannois-worship.com",
                EmailConfirmed = true,
                NormalizedUserName = "admin"
            };

            var createAdminResult = await userManager.CreateAsync(adminUser, "AdminPassword123!");

            if (createAdminResult.Succeeded)
            {
                // Assigner le rôle 'Admin' à cet utilisateur
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
