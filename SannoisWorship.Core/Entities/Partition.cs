namespace SannoisWorship.Core.Entities;

public class Partition
{
    public int Id { get; set; }
    public string Contenu { get; set; } = string.Empty; // Contenu ChordPro
    public int ChantId { get; set; }
    public Chant Chant { get; set; } = new();

    // Relation One-to-Many avec Accord
    public ICollection<Accord>? Accords { get; set; } 
}
