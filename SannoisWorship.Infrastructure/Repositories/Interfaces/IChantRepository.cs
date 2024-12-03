using SannoisWorship.Core.Entities;

namespace SannoisWorship.Infrastructure.Repositories.Interfaces;

public interface IChantRepository
{
    Task<List<Chant>> GetAllAsync();
    Task<Chant?> GetByIdAsync(int id);
    Task AddAsync(Chant chant);
    Task UpdateAsync(Chant chant);
    Task DeleteAsync(int id);
}
