using SannoisWorship.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace SannoisWorship.Application.DTOs;

public class ChantDTO
{

    public int Id { get; set; }
    [Required(ErrorMessage = "Le titre est requis.")]
    public string Titre { get; set; } = string.Empty;

    [Required(ErrorMessage = "L'auteur est requis.")]
    public string Auteur { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "La tonalité est requis.")]
    
    public string Tonalite { get; set; } = string.Empty;
    
    public string CreatedBy { get; set; } = string.Empty; // Identifiant ou nom de l'utilisateur créateur
 
    // public ICollection<ChantInstrument> ChantInstruments { get; set; }
    //public ICollection<PartitionAnnotation> PartitionAnnotations { get; set; }

    public PartitionDTO? PartitionDTO { get; set; }
}
