using AutoMapper;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using SannoisWorship.Application.DTOs;
using SannoisWorship.Application.Interfaces;
using SannoisWorship.Core.Entities;
using SannoisWorship.Infrastructure.Repositories.Interfaces;
using System.Text.RegularExpressions;

namespace SannoisWorship.Application.Services;

public class PartitionService : IPartitionService
{
    private readonly IPartitionRepository _partitionRepository;
    private readonly IMapper _mapper;
    public PartitionService(IPartitionRepository partitionRepository, IMapper mapper)
    {
        _partitionRepository = partitionRepository;
        _mapper = mapper;
    }

    public async Task<List<PartitionDTO>> GetAllPartitionsAsync()
    {
      var partitons = await _partitionRepository.GetAllAsync();

        return _mapper.Map<List<PartitionDTO>>(partitons);
    }

    public async Task<PartitionDTO?> GetPartitionByIdAsync(int id)
    {
        var partition = await _partitionRepository.GetByIdAsync(id);

        return _mapper.Map<PartitionDTO>(partition);

    }

    public async Task AddPartitionAsync(PartitionDTO partitionDTO)
    {
        var partition = _mapper.Map<Partition>(partitionDTO);

        await _partitionRepository.AddAsync(partition);
    }

    public async Task UpdatePartitionAsync(PartitionDTO partitionDTO)
    {
        var partition = _mapper.Map<Partition>(partitionDTO);


        await _partitionRepository.UpdateAsync(partition);
    }

    public async Task DeletePartitionAsync(int id)
    {
        await _partitionRepository.DeleteAsync(id);
    }


    public string ConvertToChordProFromPdf(string pdfFilePath)
    {
        if (!File.Exists(pdfFilePath))
            throw new FileNotFoundException($"Le fichier PDF spécifié est introuvable : {pdfFilePath}");


        string text = string.Empty;
        using (PdfReader reader = new(pdfFilePath))
        using (PdfDocument pdfDoc = new(reader))
        {
            for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
            {
                text += PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page)) + "\n";

            }
           
        }
        return ConvertToChordPro(text);
    }

    private string ConvertToChordPro(string pdfText)
    {
        // Expression régulière pour repérer les accords
        string chordPattern = @"\b([A-G](#|b)?(maj|min|dim|aug|sus|add|m)?(2|4|5|6|7|9|11|13)?(sus2|sus4|add9|m7|maj7|7|9|11|13)?(\/[A-G](#|b)?)?)\b";

        // Préparer le texte ChordPro
        string chordProText = "{title: Nom du chant}\n{artist: Artiste}\n{key: C}\n\n";

        // Découper les lignes du texte
        string[] lines = pdfText.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            // Si on trouve un accord, on l'encadre par des crochets []
            var convertedLine = Regex.Replace(line, chordPattern, m => $"[{m.Value}]");
            chordProText += convertedLine + "\n";
        }

        return chordProText;
    }
}
