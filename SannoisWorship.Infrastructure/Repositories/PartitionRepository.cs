using Microsoft.EntityFrameworkCore;
using SannoisWorship.Core.Entities;
using SannoisWorship.Infrastructure.Data;
using SannoisWorship.Infrastructure.Repositories.Interfaces;

namespace SannoisWorship.Infrastructure.Repositories;

public class PartitionRepository(SannoisWorshipDbContext context) : IPartitionRepository
{
    private readonly SannoisWorshipDbContext _context = context;

    public async Task<List<Partition>> GetAllAsync()
    {
        return await _context.Partitions.ToListAsync();
    }

    public async Task<Partition?> GetByIdAsync(int id)
    {
        return await _context.Partitions.FindAsync(id);
    }

    public async Task AddAsync(Partition partition)
    {
        await _context.Partitions.AddAsync(partition);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Partition partition)
    {
        _context.Partitions.Update(partition);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var partition = await GetByIdAsync(id);
        if (partition != null)
        {
            _context.Partitions.Remove(partition);
            await _context.SaveChangesAsync();
        }
    }
}
