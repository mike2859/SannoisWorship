using Microsoft.EntityFrameworkCore;
using SannoisWorship.Core.Entities;
using SannoisWorship.Infrastructure.Data;
using SannoisWorship.Infrastructure.Repositories.Interfaces;

namespace SannoisWorship.Infrastructure.Repositories;

public class ChantRepository(SannoisWorshipDbContext context) : IChantRepository
{
    private readonly SannoisWorshipDbContext _context = context;

    public async Task<List<Chant>> GetAllAsync()
    {
        return await _context.Chants.ToListAsync();
    }

    public async Task<Chant?> GetByIdAsync(int id)
    {
        return await _context.Chants.FindAsync(id);
    }

    public async Task AddAsync(Chant chant)
    {
        await _context.Chants.AddAsync(chant);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Chant chant)
    {
        _context.Chants.Update(chant);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var chant = await GetByIdAsync(id);
        if (chant != null)
        {
            _context.Chants.Remove(chant);
            await _context.SaveChangesAsync();
        }
    }
}
