using System.ComponentModel.DataAnnotations;

namespace SannoisWorship.Application.DTOs;

public class CreateUserModel
{
    [Required(ErrorMessage = "Le nom de l'utilisateur est requis.")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "L'email est requis.")]
    [EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Le mot de passe est requis.")]
    [MinLength(6, ErrorMessage = "Le mot de passe doit comporter au moins 6 caractères.")]
    public string Password { get; set; }

 
    [Required(ErrorMessage = "Le rôle est requis.")]
    public string Role { get; set; }
}
