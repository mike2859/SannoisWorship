using SannoisWorship.Application.Interfaces;
using SannoisWorship.Core.Entities;
using SannoisWorship.Infrastructure.Repositories.Interfaces;

namespace SannoisWorship.Application.Services;

public class ChantService : IChantService
{
    private readonly IChantRepository _chantRepository;

    public ChantService(IChantRepository chantRepository)
    {
        _chantRepository = chantRepository;
    }

    public async Task AddChantAsync(Chant chant)
    {
        await _chantRepository.AddAsync(chant);
    }

    public async Task DeleteChantAsync(int id)
    {
        await _chantRepository.DeleteAsync(id);
    }

    public async Task<List<Chant>> GetAllChantsAsync()
    {
        return await _chantRepository.GetAllAsync();
    }

    public async Task<Chant?> GetChantByIdAsync(int id)
    {
       return await _chantRepository.GetByIdAsync(id);
    }

    public async Task UpdateChantAsync(Chant chant)
    {
        await _chantRepository.UpdateAsync(chant);
    }
}
