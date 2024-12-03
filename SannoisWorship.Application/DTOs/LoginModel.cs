using System.ComponentModel.DataAnnotations;

namespace SannoisWorship.Application.DTOs;

public class LoginModel
{
    [Required(ErrorMessage = "L'email est requis.")]
    [EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
    public string Email { get; set; } = "admin@sannois-worship.com";

    [Required(ErrorMessage = "Le mot de passe est requis.")]
    [MinLength(6, ErrorMessage = "Le mot de passe doit contenir au moins 6 caractères.")]
    public string Password { get; set; } = "AdminPassword123!";

    public bool RememberMe { get; set; } = false;
}
