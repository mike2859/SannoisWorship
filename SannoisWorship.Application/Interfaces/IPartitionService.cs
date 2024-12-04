using SannoisWorship.Application.DTOs;
using SannoisWorship.Core.Entities;

namespace SannoisWorship.Application.Interfaces
{
    public interface IPartitionService
    {
        Task<List<Partition>> GetAllPartitionsAsync();

        Task<Partition?> GetPartitionByIdAsync(int id);
        Task AddPartitionAsync(PartitionDTO partitionDTO);
        Task UpdatePartitionAsync(PartitionDTO partitionDTO);
        Task DeletePartitionAsync(int id);

    }
}
