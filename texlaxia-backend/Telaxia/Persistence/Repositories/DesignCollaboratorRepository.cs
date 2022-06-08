using Microsoft.EntityFrameworkCore;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Repositories;
using texlaxia_backend.Telaxia.Persistence.Contexts;

namespace texlaxia_backend.Telaxia.Persistence.Repositories;

public class DesignCollaboratorRepository:BaseRepository,IDesignCollaboratorRepository
{
    public DesignCollaboratorRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<DesignCollaborator>> ListAsync()
    {
        return await _context.DesignCollaborators.ToListAsync();
    }

    public async Task AddAsync(DesignCollaborator designCollaborator)
    {
        await _context.DesignCollaborators.AddAsync(designCollaborator);
    }

    public async Task<DesignCollaborator> FindByIdAsync(int id)
    {
        return await _context.DesignCollaborators.FindAsync(id);
    }

    public void Update(DesignCollaborator designCollaborator)
    {
        _context.DesignCollaborators.Update(designCollaborator);
    }

    public void Remove(DesignCollaborator designCollaborator)
    {
        _context.DesignCollaborators.Remove(designCollaborator);
    }
}