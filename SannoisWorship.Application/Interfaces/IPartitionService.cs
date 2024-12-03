using SannoisWorship.Core.Entities;

namespace SannoisWorship.Application.Interfaces
{
    public interface IPartitionService
    {
        Task<List<Partition>> GetAllPartitionsAsync();

        Task<Partition?> GetPartitionByIdAsync(int id);
        Task AddPartitionAsync(Partition partition);
        Task UpdatePartitionAsync(Partition partition);
        Task DeletePartitionAsync(int id);

    }
}
