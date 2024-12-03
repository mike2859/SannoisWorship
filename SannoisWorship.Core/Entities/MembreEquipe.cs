using Microsoft.AspNetCore.Identity;

namespace SannoisWorship.Core.Entities;

public class MembreEquipe : IdentityUser
{
    public string Nom { get; set; }= string.Empty;

    // Liste des chants créés par ce membre
    public ICollection<Chant> CreatedChants { get; set; } = new List<Chant>();
}
