using System.ComponentModel.DataAnnotations;

namespace SannoisWorship.Application.DTOs;

public class PartitionDTO
{

    public int Id { get; set; }

    [Required(ErrorMessage = "Le contenu est requis.")]
    public string Contenu { get; set; } = string.Empty; // Contenu ChordPro
    
    public int ChantId { get; set; }
    public ChantDTO ChantDTO { get; set; } = new();

    // Relation One-to-Many avec Accord
    //public ICollection<Accord>? Accords { get; set; }
}
