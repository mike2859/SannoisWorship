using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SannoisWorship.Components;
using SannoisWorship.Infrastructure.Data;
using SannoisWorship.Infrastructure.Extensions;
using SannoisWorship.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Ajout du DbContext
builder.Services.AddDbContext<SannoisWorshipDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// Ajout de Identity avec Entity Framework Core Store
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    // Désactivation des exigences 2FA
    options.Tokens.AuthenticatorTokenProvider = null;
})
.AddEntityFrameworkStores<SannoisWorshipDbContext>()
.AddDefaultTokenProviders();

// Ajout de l'authentification Blazor
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";  // Chemin du formulaire de login
        options.LogoutPath = "/Logout";  // Chemin de déconnexion
    });

builder.Services.AddAuthorization();

//builder.Services.AddScoped<IPartitionRepository, PartitionRepository>();
//builder.Services.AddScoped<IChantRepository, ChantRepository>();


builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped<IUserManagementService, UserManagementService>();
//builder.Services.AddScoped<IPartitionService, PartitionService>();
//builder.Services.AddScoped<IChantService, ChantService>();


// Ajout des services personnalisés
builder.Services.AddSannoisWorshipServices();

builder.Services.AddApplicationServices(); // Pour AutoMapper


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}
app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(SannoisWorship.Client._Imports).Assembly);

app.Run();
