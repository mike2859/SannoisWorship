namespace SannoisWorship.Core.Entities;

public class Instrument
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;

    public ICollection<ChantInstrument> ChantInstruments { get; set; } = new List<ChantInstrument>();
}

