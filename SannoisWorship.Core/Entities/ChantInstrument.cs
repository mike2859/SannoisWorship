namespace SannoisWorship.Core.Entities;

public class ChantInstrument
{
    public int ChantId { get; set; }
    public Chant Chant { get; set; } = new();

    public int InstrumentId { get; set; }
    public Instrument Instrument { get; set; } = new();
}
