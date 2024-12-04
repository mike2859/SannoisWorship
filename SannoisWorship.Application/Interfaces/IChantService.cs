using SannoisWorship.Application.DTOs;

namespace SannoisWorship.Application.Interfaces;

public interface IChantService
{
    Task<List<ChantDTO>> GetAllChantsAsync();

    Task<ChantDTO?> GetChantByIdAsync(int id);
    Task AddChantAsync(ChantDTO chantDto);
    Task UpdateChantAsync(ChantDTO chantDto);
    Task DeleteChantAsync(int id);

}
