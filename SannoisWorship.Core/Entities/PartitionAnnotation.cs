namespace SannoisWorship.Core.Entities;

public class PartitionAnnotation
{
    public int Id { get; set; }
    public string Contenu { get; set; } = string.Empty;
    public int ChantId { get; set; }
    public Chant Chant { get; set; } = new();
}
