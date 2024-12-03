namespace SannoisWorship.Core.Entities;

public class Chant
{
    public int Id { get; set; }
    public string Titre { get; set; } = string.Empty;
    public string Auteur { get; set; } = string.Empty;
    public string Tonalite { get; set; } = string.Empty;
    public string CreatedBy { get; set; } = string.Empty; // Identifiant ou nom de l'utilisateur créateur
    public DateTime DateCreation { get; set; }
    // public ICollection<ChantInstrument> ChantInstruments { get; set; }
    //public ICollection<PartitionAnnotation> PartitionAnnotations { get; set; }

    public Partition? Partition { get; set; } 
 

}
