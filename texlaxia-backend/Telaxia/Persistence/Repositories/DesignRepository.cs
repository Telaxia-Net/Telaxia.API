using Microsoft.EntityFrameworkCore;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Repositories;
using texlaxia_backend.Telaxia.Persistence.Contexts;

namespace texlaxia_backend.Telaxia.Persistence.Repositories;

public class DesignRepository:BaseRepository,IDesignRepository
{
    public DesignRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Design>> ListAsync()
    {
        return await _context.Designs.ToListAsync();
    }

    public async Task AddAsync(Design design)
    {
        await _context.Designs.AddAsync(design);
    }

    public async Task<Design> FindByIdAsync(int id)
    {
        return await _context.Designs.FindAsync(id);
    }

    public void Update(Design design)
    {
        _context.Designs.Update(design);
    }

    public void Remove(Design design)
    {
        _context.Designs.Remove(design);
    }
}