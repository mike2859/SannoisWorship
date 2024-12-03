using SannoisWorship.Core.Entities;

namespace SannoisWorship.Infrastructure.Repositories.Interfaces;

public interface IPartitionRepository
{
    Task<List<Partition>> GetAllAsync();
    Task<Partition?> GetByIdAsync(int id);
    Task AddAsync(Partition partition);
    Task UpdateAsync(Partition partition);
    Task DeleteAsync(int id);
}
