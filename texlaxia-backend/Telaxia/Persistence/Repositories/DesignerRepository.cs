using Microsoft.EntityFrameworkCore;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Repositories;
using texlaxia_backend.Telaxia.Persistence.Contexts;

namespace texlaxia_backend.Telaxia.Persistence.Repositories;

public class DesignerRepository:BaseRepository,IDesignerRepository
{
    public DesignerRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Designer>> ListAsync()
    {
        return await _context.Designers.ToListAsync();
    }

    public async Task AddAsync(Designer designer)
    {
        await _context.Designers.AddAsync(designer);
    }

    public async Task<Designer> FindByIdAsync(int id)
    {
        return await _context.Designers.FindAsync(id);
    }

    public void Update(Designer designer)
    {
        _context.Designers.Update(designer);
    }

    public void Remove(Designer designer)
    {
        _context.Designers.Remove(designer);
    }
}