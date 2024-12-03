namespace SannoisWorship.Core.Entities;

public class Accord
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;// Exemple : "D/F#"
    public string Bass { get; set; }
    public int Frets { get; set; } // Optionnel si tu veux inclure des détails

    public string Position { get; set; } = string.Empty; // Informations de placement (cordes, frettes)


    // Relation avec Partition (nullable)
    public int? PartitionId { get; set; }
    public Partition? Partition { get; set; }
}
