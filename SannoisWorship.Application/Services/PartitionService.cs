using SannoisWorship.Application.Interfaces;
using SannoisWorship.Core.Entities;
using SannoisWorship.Infrastructure.Repositories.Interfaces;

namespace SannoisWorship.Application.Services;

public class PartitionService : IPartitionService
{
    private readonly IPartitionRepository _partitionRepository;

    public PartitionService(IPartitionRepository partitionRepository)
    {
        _partitionRepository = partitionRepository;
    }

    public async Task<List<Partition>> GetAllPartitionsAsync()
    {
        return await _partitionRepository.GetAllAsync();
    }

    public async Task<Partition?> GetPartitionByIdAsync(int id)
    {
        return await _partitionRepository.GetByIdAsync(id);
    }

    public async Task AddPartitionAsync(Partition partition)
    {
        await _partitionRepository.AddAsync(partition);
    }

    public async Task UpdatePartitionAsync(Partition partition)
    {
        await _partitionRepository.UpdateAsync(partition);
    }

    public async Task DeletePartitionAsync(int id)
    {
        await _partitionRepository.DeleteAsync(id);
    }
}
