using AutoMapper;
using SannoisWorship.Application.DTOs;
using SannoisWorship.Application.Interfaces;
using SannoisWorship.Core.Entities;
using SannoisWorship.Infrastructure.Repositories.Interfaces;

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

    public async Task<List<Partition>> GetAllPartitionsAsync()
    {
        return await _partitionRepository.GetAllAsync();
    }

    public async Task<Partition?> GetPartitionByIdAsync(int id)
    {
        return await _partitionRepository.GetByIdAsync(id);
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
}
