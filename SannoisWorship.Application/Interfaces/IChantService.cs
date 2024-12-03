using SannoisWorship.Core.Entities;

namespace SannoisWorship.Application.Interfaces;

public interface IChantService
{
    Task<List<Chant>> GetAllChantsAsync();

    Task<Chant?> GetChantByIdAsync(int id);
    Task AddChantAsync(Chant chant);
    Task UpdateChantAsync(Chant chant);
    Task DeleteChantAsync(int id);

}
