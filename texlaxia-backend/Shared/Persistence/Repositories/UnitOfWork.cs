using texlaxia_backend.Telaxia.Persistence.Contexts;
using texlaxia_backend.Shared.Domain.Repositories;

namespace texlaxia_backend.Shared.Persistence.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }


    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}